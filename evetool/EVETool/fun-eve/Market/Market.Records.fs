namespace FunEve.MarketDomain

module Records = 
    open FunEve.ProductDomain.Types
    open FunEve.OreDomain.Types
    open FunEve.OreDomain.Records
    open FunEve.OreDomain.Ore
    open FunEve.IceDomain.Types
    open FunEve.IceDomain.Records
    open FunEve.IceDomain.Ice
    open FunEve.MarketDomain.Types
    open Microsoft.FSharp.Reflection   
        
    type MarketPrices =  {
        highBuy  : single
        lowSell  : single
        lowBuy   : single
        highSell : single
    }
            
    type ParsedData<'a, 'b> = {
        buyOrders  : 'a
        sellOrders : 'b
        prices     : MarketPrices
    }


    open FunEve.MarketDomain.Types
    open FunEve.MarketDomain.Providers

    type QuickLookProvider = MarketOrder.QuickLookResult
    type SellOrderProvider = MarketOrder.QuickLookResult.Order
    type BuyOrderProvider  = MarketOrder.QuickLookResult.Order2
    
    type BuyOrder () =
        member val OrderType = "Buy" with get
        member this.GetType () = typeof<BuyOrderProvider>

    type SellOrder () =
        member val OrderType = "Sell" with get
        member this.GetType () = typeof<SellOrderProvider>

    type Order (region, station, stationName, security, range, price, volRemain, minVolume, orderType) =
        member val Region      = region
        member val Station     = station    
        member val StationName = stationName
        member val Security    = security   
        member val Range       = range      
        member val Price       = single price      
        member val VolRemain   = volRemain  
        member val MinVolume   = minVolume  
        member val OrderType   = orderType

        // F# requires that we use different constructor signatures
        // which is why we use a mostly empty class to force the
        // signatures to be different
        new (order:BuyOrderProvider, typeDef:BuyOrder) = 
            Order (   region      = order.Region
                    , station     = order.Station
                    , stationName = order.StationName
                    , security    = order.Security
                    , range       = order.Range
                    , price       = order.Price
                    , volRemain   = order.VolRemain
                    , minVolume   = order.MinVolume
                    , orderType   = typeDef.OrderType   )

        new (order:SellOrderProvider, typeDef:SellOrder) = 
            Order (   region      = order.Region
                    , station     = order.Station
                    , stationName = order.StationName
                    , security    = order.Security
                    , range       = order.Range
                    , price       = order.Price
                    , volRemain   = order.VolRemain
                    , minVolume   = order.MinVolume 
                    , orderType   = typeDef.OrderType   )