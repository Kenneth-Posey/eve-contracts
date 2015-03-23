namespace EveOnline.DataDomain

module Collections = 
    open EveOnline.ProductDomain.UnionTypes
    open EveOnline.OreDomain.Types
    open EveOnline.OreDomain.Ore
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
    
    let MineralList = 
        [
            for m in FSharpType.GetUnionCases typeof<Mineral> do
                yield FSharpValue.MakeUnion (m, [| |]) |> unbox |> Mineral
        ]

    let IceProductList = 
        [
            for p in FSharpType.GetUnionCases typeof<IceProduct> do
                yield FSharpValue.MakeUnion (p, [| |]) |> unbox |> IceProduct
        ]

    let IceList = 
        [
            for i in FSharpType.GetUnionCases typeof<IceType> do
                yield FSharpValue.MakeUnion (i, [| |]) |> unbox |> IceType
        ]
            
    let OreList = 
        [
            for o in FSharpType.GetUnionCases typeof<OreType> do
                yield FSharpValue.MakeUnion (o, [| |]) |> unbox |> OreType
        ]
        
    type oreDataFunc = (OreType -> OreRarity -> EveOnline.OreDomain.Records.OreData)
    let OreDataList = 
        let oreTypes = FSharpType.GetUnionCases typeof<EveOnline.OreDomain.Types.OreType>
        let comp x y = OreData x y EveOnline.ProductDomain.Types.Compressed.IsCompressed
        let ncomp x y = OreData x y EveOnline.ProductDomain.Types.Compressed.IsNotCompressed        

        let tuple (ore) (func:oreDataFunc) = 
            let x = FSharpValue.MakeUnion (ore, [| |]) |> unbox             
            ( (func x Common).Name.Value, (func x Uncommon).Name.Value, (func x Rare).Name.Value )

        [
            for ore in oreTypes do
                yield tuple ore comp
                yield tuple ore ncomp
        ]


    open EveOnline.ProductDomain.Types
    open EveOnline.OreDomain.Ore
    let OreDataMap = 
        [
            for oreType in FSharpType.GetUnionCases typeof<EveOnline.OreDomain.Types.OreType> do
                for common in [ Common; Uncommon; Rare ] do
                    for compressed in [ IsCompressed; IsNotCompressed ] do
                        let ore = FSharpValue.MakeUnion (oreType, [| |]) |> unbox
                        yield (RawOreName ore).Value, (ore, common, compressed)
        ]
        |> Map.ofList