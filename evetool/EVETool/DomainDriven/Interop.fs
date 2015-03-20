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

    let OreDataList = EveOnline.DataDomain.Collections.OreDataList


module Data = 
    type Ore () = 
        static member TypeIds = [ ("", 0) ]
        static member Names = InternalInterop.OreNames
        static member OreNames = InternalInterop.OreDataList
        static member Data = EveOnline.DataDomain.Collections.OreDataMap

    type Ice () = 
        static member TypeIds = [ ("", 0) ]
        static member Names = InternalInterop.IceNames

    type IceProduct () = 
        static member TypeIds = [ ("", 0) ]
        static member Names = InternalInterop.IceProductNames

    type Mineral () = 
        static member TypeIds = [ ("", 0) ]
        static member Names = InternalInterop.MineralNames

