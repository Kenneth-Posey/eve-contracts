namespace EveOnline.DataDomain

module Collections = 
    open EveOnline.ProductDomain.UnionTypes
    open EveOnline.OreDomain.Types
    open EveOnline.IceDomain.Types

    open Microsoft.FSharp.Reflection

    type SystemName =
    | Jita    = 30000142
    | Dodixie = 30002659
    | Amarr   = 30002187
    | Hek     = 30002053
    | Rens    = 30002510
    
    type Material = 
    | Mineral    of Mineral
    | IceProduct of IceProduct
    | OreType    of OreType
    | IceType    of IceType

    type OrderType = 
    | BuyOrder
    | SellOrder

    let MineralList2 = 
        [
            Mineral Isogen
            Mineral Megacyte 
            Mineral Mexallon 
            Mineral Morphite 
            Mineral Nocxium  
            Mineral Pyerite  
            Mineral Tritanium
            Mineral Zydrine  
        ]

    let MineralList = 
        [
            for mineral in FSharpType.GetUnionCases typeof<Mineral> do
                yield FSharpValue.MakeUnion(mineral, [| |]) |> unbox |> Mineral
        ]

    let IceProductList2 = 
        [
            IceProduct HeavyWater
            IceProduct HeliumIsotopes
            IceProduct HydrogenIsotopes
            IceProduct LiquidOzone
            IceProduct NitrogenIsotopes
            IceProduct OxygenIsotopes
            IceProduct StrontiumClathrates
        ]

    let IceProductList = 
        [
            for product in FSharpType.GetUnionCases typeof<IceProduct> do
                yield FSharpValue.MakeUnion (product, [| |]) |> unbox |> IceProduct
        ]

    let RefinedProducts = 
        MineralList @ IceProductList

    let IceList2 = 
        [   
            IceType BlueIce             
            IceType ClearIcicle         
            IceType DarkGlitter         
            IceType EnrichedClearIcicle 
            IceType Gelidus             
            IceType GlacialMass         
            IceType GlareCrust          
            IceType Krystallos          
            IceType PristineWhiteGlaze  
            IceType SmoothGlacialMass   
            IceType ThickBlueIce        
            IceType WhiteGlaze          
        ]

    let IceList = 
        [
            for ice in FSharpType.GetUnionCases typeof<IceType> do
                yield FSharpValue.MakeUnion (ice, [| |]) |> unbox |> IceType
        ]

    let OreList2 = 
        [
            OreType Arkonor    
            OreType Bistot     
            OreType Crokite    
            OreType DarkOchre  
            OreType Gneiss     
            OreType Hedbergite 
            OreType Hemorphite 
            OreType Jaspet     
            OreType Kernite    
            OreType Mercoxit   
            OreType Omber      
            OreType Plagioclase
            OreType Pyroxeres  
            OreType Scordite   
            OreType Spodumain  
            OreType Veldspar   
        ]
    
    let OreList = 
        [
            for ore in FSharpType.GetUnionCases typeof<OreType> do
                yield FSharpValue.MakeUnion (ore, [| |]) |> unbox |> OreType
        ]

//    let RawOreList :RawOre list = [
//        for rawOre in FSharpType.GetUnionCases typeof<OreType> do     
//            yield FSharpValue.MakeUnion(rawOre, [| box 1 |])
//                  |> unbox |> OreFactory (Common) (IsNotCompressed) (Qty 1)
//    ]
//
//    let CompressedRawOreList :RawOre list= [
//        for rawOre in FSharpType.GetUnionCases typeof<OreType> do     
//            yield FSharpValue.MakeUnion(rawOre, [| box 1 |])
//                  |> unbox |> OreFactory (Common) (IsCompressed) (Qty 1)
//    ]
//
//    let RawIceList :RawIce list = [
//        for rawIce in FSharpType.GetUnionCases typeof<IceType> do
//            yield FSharpValue.MakeUnion(rawIce, [| box 1 |])
//                  |> unbox |> IceFactory (IsNotCompressed) (Qty 1)
//    ]
//
//    let CompressedRawIceList :RawIce list = [
//        for rawIce in FSharpType.GetUnionCases typeof<IceType> do   
//            yield FSharpValue.MakeUnion(rawIce, [| box 1 |])
//                  |> unbox |> IceFactory (IsNotCompressed) (Qty 1)
//    ]
//
//
//    let AllOrePairs = List.zip RawOreList CompressedRawOreList
//    let AllOreList = RawOreList @ CompressedRawOreList
//
//    let AllIcePairs = List.zip RawIceList CompressedRawIceList
//    let AllIceList  = RawIceList @ CompressedRawIceList

    // let AllIDPairs = MineralIDPairs @ IceProductIDPairs @ RawIceIDPairs @ RawOreIDPairs
