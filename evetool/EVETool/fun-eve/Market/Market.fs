namespace FunEve.MarketDomain

module Market = 
    open FunEve.Base.Types
    open FunEve.ProductDomain.Types
    open FunEve.ProductDomain.UnionTypes
    open FunEve.ProductDomain.Records
    open FunEve.ProductDomain.Product
    open FunEve.OreDomain.Types
    open FunEve.OreDomain.Records
    open FunEve.OreDomain.Ore
    open FunEve.IceDomain.Records
    open FunEve.IceDomain.Ice
    open FunEve.MarketDomain.Types
    open FunEve.MarketDomain.Records
    open FunEve.MarketDomain.Parser
    open FunEve.DataDomain.Collections
    open FunEve.Geography.System

    // functions for finding the typeid of a material type
    let IceTypeId x = IceTypeId (x) (IsNotCompressed)
    let OreTypeId x = (OreData (x) (Common) (IsNotCompressed)).OreId

    let TypeId x = 
        match x with
        | OreType x     -> OreTypeId x
        | IceType x     -> IceTypeId x
        | Mineral x     -> MineralTypeid x
        | IceProduct x  -> IceProductTypeid x
        
    // functions for finding the name of a material type
    let Name x = 
        match x with
        | OreType x -> RawOreName x
        | IceType x -> RawIceName x
        | Mineral x    -> MineralName x
        | IceProduct x -> IceProductName x
        
    // load a material's data
    let loadItem (loc:TradeHub) (item:Material)= 
        string (TypeId item).Value
        |> baseUrl loc
        |> loadUrl
        |> parse 

    // load a list of material's data
    let loadItems (loc:TradeHub) (items:Material list) = 
        items |> List.map (fun x -> loadItem loc x)
        
    // loads ice product prices based on the highest buy offer or lowest sell offer in system
    let loadIceProductPrices (orderType:OrderType) (loc:TradeHub) :IceProductPrices = 
        let loadItem (item:Material) = Price <|
            match orderType with
            | BuyOrder  -> (loadItem loc item).prices.highBuy
            | SellOrder -> (loadItem loc item).prices.lowSell

        {
            HeavyWater          = loadItem <| IceProduct HeavyWater 
            HeliumIsotopes      = loadItem <| IceProduct HeliumIsotopes
            HydrogenIsotopes    = loadItem <| IceProduct HydrogenIsotopes
            LiquidOzone         = loadItem <| IceProduct LiquidOzone
            NitrogenIsotopes    = loadItem <| IceProduct NitrogenIsotopes
            OxygenIsotopes      = loadItem <| IceProduct OxygenIsotopes
            StrontiumClathrates = loadItem <| IceProduct StrontiumClathrates
        }


    // loads mineral prices based on the highest buy offer or lowest sell offer in system
    let loadMineralPrices (orderType:OrderType) (loc:TradeHub) :MineralPrices =
        let loadItem (item:Material) = Price <|
            match orderType with
            | BuyOrder  -> (loadItem loc item).prices.highBuy
            | SellOrder -> (loadItem loc item).prices.lowSell

        {
            Tritanium = loadItem <| Mineral Tritanium
            Pyerite   = loadItem <| Mineral Pyerite
            Mexallon  = loadItem <| Mineral Mexallon
            Isogen    = loadItem <| Mineral Isogen
            Nocxium   = loadItem <| Mineral Nocxium
            Megacyte  = loadItem <| Mineral Megacyte
            Zydrine   = loadItem <| Mineral Zydrine
            Morphite  = loadItem <| Mineral Morphite
        }
        
        
    let accumulator = fun total (refine, price) -> total + (single refine * price)
    let refineValueProcessor (pairs:(int *single) list) :Price =
        pairs |> List.fold accumulator (0.0f) |> Price

    
    // calculates the maximum market value of the yield of a single ice block
    let refineIceValue (refine:IceYield) (price:RefinePrice) :Price =          
        price 
        |> function
           | IceProductPrices x -> x
           | _ -> BaseIceProductPrices
        |> fun price -> 
            [
                refine.HeliumIsotopes.Value,    price.HeliumIsotopes.Value
                refine.HydrogenIsotopes.Value,  price.HydrogenIsotopes.Value
                refine.NitrogenIsotopes.Value,  price.NitrogenIsotopes.Value
                refine.OxygenIsotopes.Value,    price.OxygenIsotopes.Value
            
                refine.HeavyWater.Value,        price.HeavyWater.Value
                refine.LiquidOzone.Value,       price.LiquidOzone.Value
                refine.StrontiumClathrates.Value,   price.StrontiumClathrates.Value
            ]
        |> refineValueProcessor

    
    // calculates the maximum market value of the yield of 100 ore units (one refine unit)   
    let refineOreValue (refine:OreYield) (price:RefinePrice) :Price =
        price 
        |> function
           | MineralPrices x -> x
           | _ -> BaseMineralPrices
        |> fun price -> 
            [
                refine.Isogen.Value,      price.Isogen.Value    * 0.01f
                refine.Megacyte.Value,    price.Megacyte.Value  * 0.01f
                refine.Mexallon.Value,    price.Mexallon.Value  * 0.01f
                refine.Morphite.Value,    price.Morphite.Value  * 0.01f
                refine.Nocxium.Value,     price.Nocxium.Value   * 0.01f
                refine.Pyerite.Value,     price.Pyerite.Value   * 0.01f
                refine.Tritanium.Value,   price.Tritanium.Value * 0.01f
                refine.Zydrine.Value,     price.Zydrine.Value   * 0.01f
            ]
        |> refineValueProcessor
    

    // main volume function
    let GetVolume (com:Compressed) (mat:Material) :Volume = 
        match mat with
        | OreType x -> OreVolume x com
        | IceType _ -> RawIceVolume com
        | _ -> Volume 0.1f // to-do: insert actual refined product volumes
        

    // main yield function
    let GetYield (x:Material) :RefineYield = 
        match x with
        | IceType x -> IceYield <| RawIceYield x
        | OreType x -> OreYield <| RawOreYield x
        | IceProduct _ -> IceYield <| BaseIceYield
        | Mineral _ -> OreYield <| BaseOreYield


    // main refine function
    let GetRefineValue (refine:RefineYield) (price:RefinePrice) :Price =
        match refine with
        | OreYield x -> refineOreValue x price
        | IceYield x -> refineIceValue x price
        

    // Ported from Market.Functions.CalculateEstimate in OOP code
    let CalculateEstimateOre (rawList:string list) =
        // MineralPrices is a member of a union case here, so this is 
        // essentially upcasting MineralPrices to RefinePrice
        let mineralPrices = RefinePrice.MineralPrices <| loadMineralPrices SellOrder Jita 

        let calcValue (item:string * int) = 
            let oreType, oreRarity, _ = OreDataMap.Item (fst item)                    
            let refineValue = GetRefineValue (GetYield (OreType oreType)) mineralPrices
            match oreRarity with
                | Common -> refineValue.Value
                | Uncommon -> refineValue.Value * 1.05f
                | Rare -> refineValue.Value * 1.1f
            |> fun x -> double x * (double (snd item))
                    
        let SumItems (items:(string * int) list) =
            let rec SumRec (items:(string * int) list) (total:double) = 
                match items.Length with 
                // There's still items in the list to process
                | length when length > 0 ->
                    let value = calcValue items.Head
                    SumRec items.Tail (total + value)
                // In all other cases we want to just return a total
                | _ -> total 

            SumRec items 0.0

        rawList 
        |> List.map (fun x -> x.Split [|'\t'|])
        |> List.map (fun x -> string(x.[0]), int(x.[1]))
        |> SumItems 

    let CalculateEstimateIce (rawList:string list) =
        // MineralPrices is a member of a union case here, so this is 
        // essentially upcasting MineralPrices to RefinePrice
        let iceProductPrices = RefinePrice.IceProductPrices <| loadIceProductPrices SellOrder Jita

        let calcValue (item:string * int) = 
            let iceType, _ = IceDataMap.Item (fst item)                    
            GetRefineValue (GetYield (IceType iceType)) iceProductPrices
            |> fun x -> double x.Value * (double (snd item))
                    
        let SumItems (items:(string * int) list) =
            let rec SumRec (items:(string * int) list) (total:double) = 
                match items.Length with 
                // There's still items in the list to process
                | length when length > 0 ->
                    let value = calcValue items.Head
                    SumRec items.Tail (total + value)
                // In all other cases we want to just return a total
                | _ -> total 

            SumRec items 0.0

        rawList 
        |> List.map (fun x -> x.Split [|'\t'|])
        |> List.map (fun x -> string(x.[0]), int(x.[1]))
        |> SumItems 

        
    // this should be cleaned up later. 3-30-2015
    open FunEve.DataDomain.Collections
    type MaterialNameId = {
        Name : Name
        Id : TypeId 
    }
    let MaterialNameIdList = 
        [
            for mat in Materials do
                yield {
                    Name = Name mat
                    Id   = TypeId mat
                }
        ]

    // this should be cleaned up later. 3-30-2015
    let internal loadPrice mat = (loadItem Jita mat).prices
    type MaterialData = {
        Name  : Name
        Id    : TypeId
        Value : Price
    }

    let LoadRefinedMaterialPricesHighBuy () = 
        [
            for mat in IceProductList @ MineralList do
                yield {
                    Name = Name mat
                    Id = TypeId mat
                    Value = Price (loadPrice mat).highBuy
                }
        ]        

    let LoadRefinedMaterialPricesLowSell () = 
        [
            for mat in IceProductList @ MineralList do
                yield {
                    Name = Name mat
                    Id = TypeId mat
                    Value = Price (loadPrice mat).lowSell
                }
        ]

    // this is code that I want to keep, but I'm not going to comment
    // it to avoid commented code rot
    module internal unusedCode = 
        // If I have the volume of 100 units and the value of 100 units, I can work out
        // the value per m^3 by dividing the value by the volume
        let GetVolumePrice (vol:Volume) price com mat :Price =         
            GetYield mat
            |> fun _yield -> GetRefineValue _yield price
            |> fun refine -> refine, GetVolume com mat
            |> fun (refine, unitVolume) -> refine.Value / unitVolume.Value * vol.Value
            |> Price
        
        // main refined product price function
        let GetPrice material order loc :RefinePrice = 
            match material with
            | RefinedProduct.Mineral     -> MineralPrices    <| loadMineralPrices order loc
            | RefinedProduct.IceProduct  -> IceProductPrices <| loadIceProductPrices order loc
