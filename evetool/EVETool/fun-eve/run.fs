
namespace FunEve.Main

open System
open System.Net
open System.Text


module main = 
    open FunEve.Contracts
    type ContractListing = FunEve.Contracts.Contracts.XmlCourierContractListing
    type ContractRow = FunEve.Contracts.Contracts.XmlCourierContractRow

    let runApi () = 
        let keyId = FunEve.PlecoApiKeys.PMGE.keyId
        let vCode = FunEve.PlecoApiKeys.PMGE.vCode
        
        Contracts.LoadCorpContracts keyId vCode
                
    let runCrest () = 
        let url = @"https://crest-tq.eveonline.com/"    
        
        let body = Encoding.ASCII.GetBytes """{ "refresh_token" : "NmdnNMsujSf4nku2IAbhro_RN0BocfnYuB4bRWZFgdnBvE4E4OZKzF9IWFepmlx30" }"""
        let request = WebRequest.Create(new Uri(url))
        request.ContentType <- "application/json"
        request.ContentLength <- body.LongLength
        
        request.Method <- "POST"
        request.Headers.Add ("User-Agent", "test application")
        
        let requestStream = request.GetRequestStream()
        requestStream.Write (body, 0, body.Length)
        requestStream.Close ()

        ()

// module mainEveLib =     
//     open eZet.EveLib
//     let runEveLib () = 
//         // these are invalid now
//         let accessToken = @"7q5-F9zUeZ6Orn-L8VHpH7s82nz3UkoYZbaqvDCvnuM4V8Q6xJzLgV_NDoexn08v5EDPJFHXp6WF1PHcTL-ZxQ2"
//         let refreshToken = @"NmdnNMsujSf4nku2IAbhro_RN0BocfnYuB4bRWZFgdnBvE4E4OZKzF9IWFepmlx30"
//         let encodedKey = @"MXRJSWMzaVlSMjNGWmNTN0t1eGh6cXVGZFFxM1BqekRUVGpaamZIdQ=="
//         let eveCrest = new EveCrestModule.EveCrest(refreshToken, encodedKey)
//         














        ()



