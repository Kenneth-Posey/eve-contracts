namespace FunEve.MarketDomain

module Types = 
    open FunEve.OreDomain.Records
    open FunEve.IceDomain.Records
    open FunEve.ProductDomain.Records


    type RefinePrice = 
    | MineralPrices of MineralPrices
    | IceProductPrices of IceProductPrices

    type RefineYield = 
    | IceYield of IceYield 
    | OreYield of OreYield

    type RefinedProduct = 
    | Mineral
    | IceProduct

