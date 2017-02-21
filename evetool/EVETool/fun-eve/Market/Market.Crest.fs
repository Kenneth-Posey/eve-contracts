namespace FunEve.MarketDomain

module Crest = 
    open System
    open FSharp.Data

    module PathsSisi = 
        let PublicEndpoint = "http://public-crest-sisi.testeveonline.com/"
        let AuthedEndpoint = "https://api-sisi.testeveonline.com/"
        let ImageServer = "https://image.testeveonline.com/"
        let OAuthEndpoint = "https://sisilogin.testeveonline.com/oauth"

    module PathsTQ = 
        let PublicEndpoint = "https://crest-tq.eveonline.com/"
        let AuthedEndpoint = "https://crest-tq.eveonline.com/"
        let ImageServer = "https://image.eveonline.com/"
        let OAuthEndpoint = "https://login.eveonline.com/oauth"
    
    module test = 
        type CrestProvider = JsonProvider<"https://crest-tq.eveonline.com/">
        // Download the content of a web site
        let content = Http.RequestString("https://crest-tq.eveonline.com/")
        let crestMain = CrestProvider.Parse content
        
        type MarketProvider = JsonProvider<"https://crest-tq.eveonline.com/market/prices/">
        let market = Http.RequestString("https://public-crest.eveonline.com/market/prices/")
        let marketMain = MarketProvider.Parse market
        let itemTypes = marketMain.Items.[0]


    
    
        let t = crestMain.Regions.Href
