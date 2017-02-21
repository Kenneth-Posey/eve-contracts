
namespace FunEve.Crest

open System
open System.Text
open FSharp
open FSharp.Data

// Turns out that they don't require authentication for market
// so we're not going to pursue this path for a while
module AuthManager = 
    let HOST = "https://login.eveonline.com"

    let EncodeIdentifier (clientId:string) (clientSecret:string) = 
        let textBytes = Encoding.UTF8.GetBytes(clientId + ":" + clientSecret)
        Convert.ToBase64String(textBytes)

    let ConvertAuthLink clientId redirectUri state scopes =     
        HOST 
        + "/oauth/authorize/?response_type=code&redirect_uri=" + redirectUri
        + "&client_id=" + clientId 
        + "&scope=" + scopes 
        + "&state=" + state        

    let Authenticate encodedKey authCode = 
        
        ()
