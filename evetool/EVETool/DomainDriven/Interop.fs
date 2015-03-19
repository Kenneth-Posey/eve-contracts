namespace EveOnline.Interop

module internal InternalInterop = 
    open EveOnline.ProductDomain.Types
    open EveOnline.MarketDomain
    open EveOnline.DataDomain.Collections

    type i = {
        material : Material
        typeid : TypeId
        name : Name
    }

    let generator list = 
        [
            for x in list do
                yield {
                    material = x
                    typeid = Market.TypeId x
                    name = Market.Name x
                }
        ]
        
    let name x = x |> List.map (fun x -> x.name.Value)

    let Minerals = generator MineralList        
    let IceProducts = generator IceProductList
    let Ore = generator OreList
    let Ice = generator IceList

    let OreNames = name Ore
    let IceNames = name Ice
    let IceProductNames = name IceProducts
    let MineralNames = name Minerals


module CollectionsProvider = 
    type OreNameList () = 
        static member OreNames = 
            List.toSeq <| InternalInterop.OreNames

    type IceNameList () = 
        static member IceNames = 
            List.toSeq <| InternalInterop.IceNames

    type IceProductNameList () = 
        static member IceProductNames = 
            List.toSeq <| InternalInterop.IceProductNames

    type MineralNameList () = 
        static member MineralNames = 
            List.toSeq <| InternalInterop.MineralNames

