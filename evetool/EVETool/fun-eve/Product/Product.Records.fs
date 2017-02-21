namespace FunEve.ProductDomain
open FunEve.Base.Types
open FunEve.ProductDomain.UnionTypes

module Records = 

    type MineralData = {
        TypeId  : TypeId
        Name    : Name
        Mineral : Mineral
    }

    type MineralPrices = {
        Tritanium   : Price
        Pyerite     : Price
        Mexallon    : Price
        Isogen      : Price
        Nocxium     : Price
        Megacyte    : Price
        Zydrine     : Price
        Morphite    : Price
    }

    let BaseMineralPrices = 
        Price 0.0f 
        |> fun x -> {
            Tritanium   = x
            Pyerite     = x
            Mexallon    = x
            Isogen      = x
            Nocxium     = x
            Megacyte    = x
            Zydrine     = x
            Morphite    = x
        }

    type IceProductData = {
        TypeId     : TypeId
        Name       : Name
        IceProduct : IceProduct
    }
    
    type IceProductPrices = {
        HeavyWater          : Price
        HeliumIsotopes      : Price
        HydrogenIsotopes    : Price
        LiquidOzone         : Price
        NitrogenIsotopes    : Price
        OxygenIsotopes      : Price
        StrontiumClathrates : Price
    }

    let BaseIceProductPrices = 
        Price 0.0f 
        |> fun x -> {
            HeavyWater          = x
            HeliumIsotopes      = x
            HydrogenIsotopes    = x
            LiquidOzone         = x
            NitrogenIsotopes    = x
            OxygenIsotopes      = x
            StrontiumClathrates = x
        }
