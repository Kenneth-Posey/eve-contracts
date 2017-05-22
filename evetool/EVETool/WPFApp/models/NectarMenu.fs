namespace WPFApp

open System
open ViewModule
open ViewModule.FSharp

open FunEve.Utility

module NectarModelFunctions =          
    open System.Text.RegularExpressions
    open System.Web   

    type StrainRow = {
        Name: string
        ItemId: int
        Score: string
        Description: string
        Prices: (float * string) list
    }
    
    let parse input regex (groupName:string) = 
        let m = (new Regex(regex)).Matches(input)

        match m.Count > 0 with
        | true -> m.Item(0).Groups.Item(groupName).Value.Trim()
        | false -> ""

    let itemIdPattern = "(?>item-id=\\\")(?<strainid>[0-9]*)(?>[\\\"])"
    let namePattern = "(?>item-name=\\\")(?<name>.*?)(?>\\\" )"
    let scorePattern = "(?>score[\\\">]{3}\\r\\n[ ]*)(?<score>[0-9of .]*)"
    let descriptionPattern = "(?>item-heading--description[a-z-0-9 ]*\\\">\\r\\n[ ]*)(?<desc>[\w |:.%#;&]*)"
    let pricesPattern = "(?>(?>item-heading--price[\s\S]*?>\$)(?<price>[0-9]*?)(?></span[\s\S]*?hidden-xs[\s\S]*?\\\">)(?<qty>[a-zA-Z]*?)</span)+?"
    let itemPattern = "(?<item>(?>\\r\\n[ ]{20}<div)[\s\S]+?(?>\\r\\n[ ]{20}</div))"
        
    let dispensaryLinkPattern = "(?>dispensary-info\\/)(?<link>[a-zA-Z0-9-]+?)(?>[\\\"])"
    let cityLinkPattern = "(?>finder/)(?<link>[a-zA-Z0-9-]+?)(?>[\\\"])"
    let regionLinkPattern = "(?>divider-top[a-z- ]+\\\">)(?<region>[a-zA-Z0-9-]+?)<(?<html>[\s\S]+?)(?>\\r\\n[ ]{32}</div)"

    let parseItemId input = 
        int <| parse input itemIdPattern "strainid"        
        
    let parseName input = 
        parse input namePattern "name"

    let parseScore input = 
        parse input scorePattern "score"
        
    let parseDescription input = 
        parse input descriptionPattern "desc"

    let parsePrices input = 
        [
            for pricematch in (new Regex(pricesPattern)).Matches(input) do
                let price = float <| pricematch.Groups.Item(1).Value
                let qty = pricematch.Groups.Item(2).Value
                yield price, qty
        ]
        
    let parseText text = 
        {
            Name = parseName text |> HttpUtility.HtmlDecode
            ItemId = parseItemId text
            Score = "" // parseScore text
            Description = parseDescription text |> HttpUtility.HtmlDecode
            Prices = parsePrices text
        }

    let strainWriter (strain:StrainRow) (headers:string array) = 
        // seed the list with the name to avoid a comma at the front of the string
        // refactor later with accumulated string to avoid mutable row value
        let mutable row = strain.Name
        for header in headers do
            let value = 
                match header with 
                | "Description" -> strain.Description
                | _ -> 
                    let matcher = (fun (x,y) -> y = header)
                    if (List.exists matcher strain.Prices) then
                        let price, qty = (List.where (matcher) strain.Prices).[0]
                        price.ToString()
                    else
                        "0.0"                       
            row <- row + "," + value             
        row
            
    let extractItems (targetType:string) (inputHtml:string) = 
        // first extract the chunk that corresponds to the menu of a type of item
        let baseRegex = "(?>hideSection\['" + targetType + "']\\\")(?:[\s\S]+?)(?>\r\n[ ]{12}</div)" 
        let mainListChunk = (new Regex(baseRegex)).Match(inputHtml).Value

        // then extract the individual menu items
        let itemMatches = (new Regex(itemPattern)).Matches(mainListChunk)

        [
            for menuMatch in itemMatches do
                yield menuMatch.Value.ToString()
        ]

    let extractDispensaries (inputHtml:string) =         
        [            
            for dispensaryMatch in (new Regex(dispensaryLinkPattern)).Matches(inputHtml) do
                let link = dispensaryMatch.Value.TrimEnd [|'\\'; '"' |]
                yield (sprintf @"https://www.leafly.com/%s/menu" link)
        ]

    let extractCityLinks (inputHtml:string) = 
        [            
            for cityMatch in (new Regex(cityLinkPattern)).Matches(inputHtml) do
                let link = cityMatch.Value.TrimEnd [|'\\'; '"' |]
                yield (sprintf @"https://www.leafly.com/%s/" link)
        ]

    let extractRegions (inputHtml:string) = 
        [            
            for regionMatch in (new Regex(regionLinkPattern)).Matches(inputHtml) do
                let regionName = regionMatch.Groups.Item(1).Value
                let regionHtml = extractCityLinks <| regionMatch.Groups.Item(2).Value
                yield regionName, regionHtml
        ]

    let extractQuantities (x:StrainRow) =         
        List.fold (fun acc (price, quantity) -> quantity :: acc) [] x.Prices

    let writefile filename parsedItems =         
        let headers = 
            Array.fold (fun acc x -> acc @ extractQuantities(x)) [] parsedItems 
            |> fun x -> ["Name"; "Description"] @ x
            |> List.distinct  
            |> Array.ofList
             
        // let mutable fileRows:string list = []
        // fileRows <- String.Join(",", headers).ToString() :: fileRows
        // for item in parsedItems do
        //     fileRows <- strainWriter item headers :: fileRows 
        // fileRows <- List.rev fileRows

        let fileDir = System.IO.Path.GetDirectoryName(filename)
        if System.IO.Directory.Exists(fileDir) <> true then System.IO.Directory.CreateDirectory(fileDir) |> ignore
        
        if System.IO.File.Exists(filename) then System.IO.File.Delete(filename)
        use file = new System.IO.StreamWriter(filename, true)
        
        String.Join(",", headers) |> file.WriteLine
        for item in parsedItems do
            strainWriter item headers |> file.WriteLine
        file.Flush()        

    let processMenu inputHtml =
        let regions = extractRegions inputHtml
                
        let oregon = [
            for name, cities in regions do 
                if String.Equals(name, "Oregon") then
                    yield name, cities
        ]
        
        let oregonDispensaries = [
            let name, cities = oregon.Head 

            // shortening the number of cities to retrieve for faster testing
            // let cities = List.truncate 2 oregon.Head.Item2
            for city in cities do           
                let html = HttpTools.loadWithEmptyResponse city ""
                let dispensaries = extractDispensaries html

                // shortening the number of dispensaries to retrieve for faster testing
                // let dispensaries = List.truncate 2 (extractDispensaries html)

                yield name, city, dispensaries
        ]

        let oregonMenus = [
            for state, city, dispensaries in oregonDispensaries do
                for dispensary in dispensaries do
                    let menu = extractItems "Concentrate" <| HttpTools.loadWithEmptyResponse dispensary ""
                    let items = Array.Parallel.map parseText (Array.ofList menu)     
                    let safeName = dispensary.Split('/') |> fun x -> x.[x.Length - 2]
                    let safeCity = city.Split('/') |> fun x -> x.[x.Length - 2]
                    let filename = 
                        System.IO.Path.Combine [|
                                Environment.SpecialFolder.MyDocuments |> Environment.GetFolderPath
                                "output-documents"
                                state
                                safeCity
                                safeName + ".csv"
                            |]
            
                    writefile filename items                
                    yield (state, city, dispensary, items)
        ]
        
        ()


open NectarModelFunctions
type NectarMenuViewModel () as this = 
    inherit ViewModelBase ()

    // let url = @"https://www.leafly.com/dispensary-info/nectar-3/menu"
    // let cityurl = @"https://www.leafly.com/finder/albany-or"
    let browseUrl = @"https://www.leafly.com/finder/browse"

    let mutable inputHtml = ""    
    let processMenuHtml = 
        this.Factory.CommandSync (fun x -> 
            HttpTools.loadWithEmptyResponse browseUrl "" |> processMenu)

    member this.InputHtml 
        with get () = inputHtml
        and set (value) = inputHtml <- value

    member this.ProcessMenu = processMenuHtml