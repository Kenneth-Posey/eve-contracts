module WebServers
 
open System
open System.IO
open Nancy
open Nancy.Hosting.Self
open Nancy.Conventions
 
let (?) (this : obj) (prop : string) : obj =
    (this :?> DynamicDictionary).[prop]
 
let siteRoot = @"website\"
 
type SSOWebServerModule() as this =
    inherit NancyModule() 
    
    do this.Get.["/eveauth"] <- 
        fun paramaters -> 
            this.SSOKey <- paramaters.ToString()
            this.IsSSOSet <- true
            
            new Nancy.Responses.TextResponse(
                "Authenticated"
            ) :> obj

    do this.Get.["{file}"] <-
        fun paramaters ->
              new Nancy.Responses.HtmlResponse(
                  HttpStatusCode.OK,
                  (fun (s:Stream) ->
                      let file = (paramaters?file).ToString()
                      printfn "Requested : '%s'" file
                      let bytes = File.ReadAllBytes(Path.Combine(siteRoot, file))
                      s.Write(bytes,0,bytes.Length)
              )) :> obj


    let mutable _ssoKey = ""
    let mutable _isSSOSet = false

    member this.SSOKey 
        with public get() = _ssoKey
        and public set(value) = _ssoKey <- value
    member this.IsSSOSet
        with public get() = _isSSOSet
        and public set(value) = _isSSOSet <- value

 
let startAt host =
    let nancyHost = new NancyHost(new Uri(host))
    nancyHost.Start()
    nancyHost

let start () = 
    startAt "http://localhost:19860/"
// printfn "Press [Enter] to exit."
// Console.ReadKey() |> ignore

let stop (server:NancyHost) =
    server.Stop()