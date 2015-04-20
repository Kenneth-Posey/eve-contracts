namespace EveOnline.MarketDomain

module Crest = 
    open System
    open System.Net

    module PathsSisi = 
        let PublicEndpoint = "http://public-crest-sisi.testeveonline.com/"
        let AuthedEndpoint = "https://api-sisi.testeveonline.com/"
        let ImageServer = "https://image.testeveonline.com/"
        let OAuthEndpoint = "https://sisilogin.testeveonline.com/oauth"

    module PathsTQ = 
        let PublicEndpoint = "https://public-crest.eveonline.com/"
        let AuthedEndpoint = "https://crest-tq.eveonline.com/"
        let ImageServer = "https://image.eveonline.com/"
        let OAuthEndpoint = "https://login.eveonline.com/oauth"
    
    type CrestConnection (username:string, password:string) = 
        let headers = new WebHeaderCollection ()       
        let client = new WebClient ()
        let longauthcode = ""
        let authtoken = ""

        do 
            let marketUrl = "https://crest-tq.eveonline.com/market/"
            let hval = HttpRequestHeader.Authorization.ToString() + " : Bearer " + authtoken
            headers.Add hval


        interface IDisposable with 
            member this.Dispose () = 
                this.Client.Dispose ()                

                
        member this.Client = client
        




