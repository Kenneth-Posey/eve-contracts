namespace FunEve.DataDomain

module Collections = 
    open FunEve.ProductDomain.UnionTypes
    open FunEve.OreDomain.Types
    open FunEve.IceDomain.Types
    open FunEve.ProductDomain.Types
    open FunEve.OreDomain.Ore
    open FunEve.OreDomain.Records
    open FunEve.IceDomain.Ice
    open FunEve.IceDomain.Records

    open Microsoft.FSharp.Reflection

    type SystemName =
    | Jita    = 30000142
    | Dodixie = 30002659
    | Amarr   = 30002187
    | Hek     = 30002053
    | Rens    = 30002510
    
    // Using a union case here to enable functions to operate on all types
    // of ore, ice and refined materials
    type Material = 
    | Mineral    of Mineral
    | IceProduct of IceProduct
    | OreType    of OreType
    | IceType    of IceType

    type OrderType = 
    | BuyOrder
    | SellOrder

    // hidden helper functionality
    module internal internalModule = 
        let OreUnionCases = FSharpType.GetUnionCases typeof<OreType>
        let makeOreType x = FSharpValue.MakeUnion (x, [| |]) |> unbox<OreType>
        let makeOreMaterial x = makeOreType x |> Material.OreType

        let IceUnionCases = FSharpType.GetUnionCases typeof<IceType>
        let makeIceType x = FSharpValue.MakeUnion (x, [| |]) |> unbox<IceType>
        let makeIceMaterial x = makeIceType x |> Material.IceType

        let IceProductUnionCases = FSharpType.GetUnionCases typeof<IceProduct>
        let makeIceProductType x = FSharpValue.MakeUnion (x, [| |]) |> unbox<IceProduct>
        let makeIceProductMaterial x = makeIceProductType x |> Material.IceProduct

        let MineralUnionCases = FSharpType.GetUnionCases typeof<Mineral>
        let makeMineralType x = FSharpValue.MakeUnion (x, [| |]) |> unbox<Mineral>
        let makeMineralMaterial x = makeMineralType x |> Material.Mineral

    open internalModule

    let OreTypeList = [ for x in OreUnionCases do yield makeOreType x ]
    let OreList = [ for x in OreUnionCases do yield makeOreMaterial x ]       
            
    let MineralTypeList = [ for x in MineralUnionCases do yield makeMineralType x ]
    let MineralList = [ for x in MineralUnionCases do yield makeMineralMaterial x ]
        
    let IceTypeList = [ for x in IceUnionCases do yield makeIceType x ]
    let IceList = [ for x in IceUnionCases do yield makeIceMaterial x ]

    let IceProductTypeList = [ for x in IceProductUnionCases do yield makeIceProductType x ]
    let IceProductList = [ for x in IceProductUnionCases do yield makeIceProductMaterial x ] 

    let Materials = OreList @ MineralList @ IceList @ IceProductList
        
    let OreNameList = 
        let buildTuple (ore) (compressed) = 
            fun oreRarity -> (OreData ore oreRarity compressed).Name.Value
            |> fun getName -> (getName Common, getName Uncommon, getName Rare)

        [
            for ore in OreTypeList do
                for compressed in [ IsCompressed; IsNotCompressed; ] do                    
                    yield buildTuple ore compressed
        ]
        
    let OreDataMap = 
        [
            for ore in OreTypeList do
                for rarity in [ Common; Uncommon; Rare ] do
                    for compressed in [ IsCompressed; IsNotCompressed; ] do
                        yield (RawOreName ore).Value, (ore, rarity, compressed)
        ]
        |> Map.ofList
    

    let IceDataMap = 
        [
            for ice in IceTypeList do
                for compressed in [ IsCompressed; IsNotCompressed ] do
                    yield (RawIceName ice).Value, (ice, compressed)
        ]
        |> Map.ofList