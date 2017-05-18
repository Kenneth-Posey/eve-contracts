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
    
    let parse input regex = (new Regex(regex)).Match(input).Value.Trim()

    let itemIdPattern = "(?>item-id=\\\")(?<strainid>[0-9]*)(?>[\\\"])"
    let namePattern = "(?>item-name=\\\")(?<name>[\w ;&'#-]*)(?>\\\")"
    let scorePattern = "(?>score[\\\">]{3}\\r\\n[ ]*)(?<score>[0-9of .]*)"
    let descriptionPattern = "(?>item-heading--description[a-z-0-9 ]*\\\">\\r\\n[ ]*)(?<desc>[\w |:.%#;&]*)"
    let pricesPattern = "(?>(?>item-heading--price[\s\S]*?>\$)(?<price>[0-9]*?)(?></span[\s\S]*?hidden-xs[\s\S]*?\\\">)(?<qty>[a-zA-Z]*?)</span)+?"
    let itemPattern = "(?<item>(?>\\r\\n[ ]{20}<div)[\s\S]+?(?>\\r\\n[ ]{20}</div))"
        
    let dispensaryLinkPattern = "(?>dispensary-info\\/)(?<link>[a-zA-Z0-9-]+?)(?>[\\\"])"
    let cityLinkPattern = "(?>finder/)(?<link>[a-zA-Z0-9-]+?)(?>[\\\"])"
    let regionLinkPattern = "(?>divider-top[a-z- ]+\\\">)(?<region>[a-zA-Z0-9-]+?)<(?<html>[\s\S]+?)(?>\\r\\n[ ]{32}</div)"

    let parseItemId input = 
        int <| parse input itemIdPattern
        
    let parseName input = 
        parse input namePattern

    let parseScore input = 
        parse input scorePattern
        
    let parseDescription input = 
        parse input descriptionPattern

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

    let strainWriter (strain:StrainRow) = 
        // refactor to pattern match the prices into the columns
        // to avoid issues with odd priced strains
        let normalizedPrices = 
            match strain.Prices.Length with
            | x when x <= 4 -> 
               (0.0, "") :: strain.Prices
            | _ -> 
                strain.Prices

        let gramprice, _ = normalizedPrices.[0]
        let eighthprice, _ = if normalizedPrices.Length > 1 then normalizedPrices.[1] else (0.0, "")
        let quarterprice, _ = if normalizedPrices.Length > 2 then normalizedPrices.[2] else (0.0, "")
        let halfprice, _ = if normalizedPrices.Length > 3 then normalizedPrices.[3] else (0.0, "")
        let ounceprice, _ = if normalizedPrices.Length > 4 then normalizedPrices.[4] else (0.0, "")
                
        sprintf "%A,%A,%A,%A,%A,%A,%A" strain.Name strain.Description gramprice eighthprice quarterprice halfprice ounceprice
                
    let extractItems (targetType:string) (inputHtml:string) = 
        // first extract the chunk that corresponds to the menu of a type of item
        let baseRegex = "(?>\r\n[ ]{12}<[\w =\\\"-]*\['" + targetType + "'\]\\\">)[\s\S]+?(?>\r\n[ ]{12}<)"
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

    let writefile filename parsedItems = 
        if System.IO.File.Exists(filename) then System.IO.File.Delete(filename)
        use file = new System.IO.StreamWriter(filename)

        let headers :string = 
            sprintf "%A,%A,%A,%A,%A,%A,%A" "Name" "Description" "Gram" "Eighth" "Quarter" "Half" "Oz"
        
        file.WriteLine(headers)
        for item in parsedItems do
            file.WriteLine(strainWriter item)
        file.Flush()        

    let processMenu inputHtml =
        // let dispensaryLinks = extractDispensaries inputHtml
        let regions = extractRegions inputHtml
                
        let oregon = [
            for name, cities in regions do 
                if String.Equals(name, "Oregon") then
                    yield name, cities
        ]

        let oregonDispensaries = [
            let name, cities = oregon.Head 
            for city in cities do           
                let html = HttpTools.loadWithEmptyResponse city ""
                let dispensaries = extractDispensaries html
                yield name, city, dispensaries
        ]

        let oregonMenus = [
            for state, city, dispensaries in oregonDispensaries do
                yield [
                    for dispensary in dispensaries do
                        let menu = extractItems "Flower" <| HttpTools.loadWithEmptyResponse dispensary ""
                        let items = Array.Parallel.map parseText (Array.ofList menu)
                        yield (state, city, dispensary, items)
            ]       
        ]
        
        let tempFolder = System.IO.Path.Combine [| Environment.SpecialFolder.MyDocuments.ToString(); "output-documents" |]
        // let filename = dispensaryname + ".csv"


        ()


open NectarModelFunctions
type NectarMenuViewModel () as this = 
    inherit ViewModelBase ()

    let url = @"https://www.leafly.com/dispensary-info/nectar-3/menu"
    let cityurl = @"https://www.leafly.com/finder/albany-or"
    let browseUrl = @"https://www.leafly.com/finder/browse"

    let mutable inputHtml = ""    
    let processMenuHtml = 
        this.Factory.CommandSync (fun x -> 
            HttpTools.loadWithEmptyResponse browseUrl "" |> processMenu)

    member this.InputHtml 
        with get () = inputHtml
        and set (value) = inputHtml <- value

    member this.ProcessMenu = processMenuHtml