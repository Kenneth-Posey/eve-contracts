namespace WPFApp

open System
open ViewModule
open ViewModule.FSharp

open FunEve.Utility

module NectarModelFunctions =          
    open System.Text.RegularExpressions
    open System.Web   
    open System.Windows.Forms
    open System.Windows.Controls

    let (|Gram|Eighth|Quarter|Half|Ounce|) qty =
        if String.Equals(qty, "Ounce", StringComparison.InvariantCultureIgnoreCase) then Ounce            
        else if String.Equals(qty, "Half", StringComparison.InvariantCultureIgnoreCase) then Half
        else if String.Equals(qty, "Quarter", StringComparison.InvariantCultureIgnoreCase) then Quarter
        else if String.Equals(qty, "Eighth", StringComparison.InvariantCultureIgnoreCase) then Eighth
        else Gram        

    type StrainRow = {
        Name: string
        ItemId: int
        Score: string
        Description: string
        Prices: (float * string) list
    }
    
    let parse input regex = 
        let parser = new Regex(regex)
        parser.Match(input).Groups.[1].Value.ToString().Trim()
        
    let parseItemId input = 
        int <| parse input "(?>item-id=\\\")(?<strainid>[0-9]*)(?>[\\\"])"
        
    let parseName input = 
        parse input "(?>item-name=\\\")(?<name>[\w ;&'#-]*)(?>\\\")"

    let parseScore input = 
        parse input "(?>score[\\\">]{3}[\S]{4}[ ]*)(?<score>[0-9of .]*)"
        
    let parseDescription input = 
        parse input "(?>item-heading--description[a-z-0-9 ]*\\\">\\r\\n[ ]*)(?<desc>[\w |:.%#;&]*)"

    let parsePrices input = 
        let pricesregex = "(?>(?>item-heading--price[\s\S]*?>\$)(?<price>[0-9]*?)(?></span[\s\S]*?hidden-xs[\s\S]*?\\\">)(?<qty>[a-zA-Z]*?)</span)+?"
        let pricesParser = new Regex(pricesregex)
        let prices = pricesParser.Matches(input)

        [
            for pricematch in prices do
                let price = float <| pricematch.Groups.Item(1).Value
                let qty = pricematch.Groups.Item(2).Value
                yield price, qty
        ]
        
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
        

    let parseText text = 
        {
            Name = parseName text |> HttpUtility.HtmlDecode
            ItemId = parseItemId text
            Score = parseScore text
            Description = parseDescription text |> HttpUtility.HtmlDecode
            Prices = parsePrices text
        }
        
    let extractItems (targetType:string) (inputHtml:string) = 
        // first extract the chunk that corresponds to the menu of a type of item
        let baseRegex = "(?>\r\n[ ]{12}<[\w =\\\"-]*\['" + targetType + "'\]\\\">)[\s\S]+?(?>\r\n[ ]{12}<)"
        let regex = new Regex(baseRegex)
        let mainListChunk = regex.Match(inputHtml).Value

        // then extract the individual menu items
        let itemPattern = "(?<item>(?>\\r\\n[ ]{20}<div)[\s\S]+?(?>\\r\\n[ ]{20}</div))"
        let itemsRegex = new Regex(itemPattern)
        let itemMatches = itemsRegex.Matches(mainListChunk)

        itemMatches

    let processMenu inputHtml =         
        let itemMatches = extractItems "Flower" inputHtml

        let parseditems = [
            for menuMatch in itemMatches do
                yield menuMatch.Value.ToString()
        ]

        let finalItems = Array.Parallel.map parseText (Array.ofList parseditems)

        if System.IO.File.Exists("output.csv") then System.IO.File.Delete("output.csv")
        use file = new System.IO.StreamWriter("output.csv")

        let headers :string = 
            sprintf "%A,%A,%A,%A,%A,%A,%A" "Name" "Description" "Gram" "Eighth" "Quarter" "Half" "Oz"
        
        file.WriteLine(headers)
        for item in finalItems do
            file.WriteLine(strainWriter item)
        file.Flush()

        ()


open NectarModelFunctions
type NectarMenuViewModel () as this = 
    inherit ViewModelBase ()

    let url = @"https://www.leafly.com/dispensary-info/nectar-3/menu"

    let mutable inputHtml = ""    
    let processMenuHtml = 
        this.Factory.CommandSync (fun x -> 
            HttpTools.loadWithEmptyResponse url "" |> processMenu)

    member this.InputHtml 
        with get () = inputHtml
        and set (value) = inputHtml <- value

    member this.ProcessMenu = processMenuHtml