namespace WPFApp

open System
open System.Threading
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FsXaml

module MainFunctions = 
    open FunEve
    open FunEve.Contracts
    module main =
        let loadInProgressCorpContracts keyId vCode =
            Contracts.LoadCorpContracts keyId vCode
            |> List.filter 
                ( fun x -> 
                    match x.Status with
                    | Contracts.ApiContractStatus.InProgress -> true
                    | _ -> false )
                
        let mainThread () = 
            let win = new MainView ()        
            let ran = new Random (DateTime.Now.Millisecond)
            let apikeys = BadNewbies.GetApiKeys()

            let mutable BREAK = false        
            while not BREAK do
                let apikey = apikeys.[ran.Next(0, apikeys.Length - 1)]
                let contracts = loadInProgressCorpContracts apikey.keyId apikey.vCode

                match contracts.Length with
                | x when x > 0 -> 
                    win.statusLabel.Content <- x.ToString() + "x CONTRACTS"
                    win.Show ()
                | _ -> 
                    win.Hide ()
                    Thread.Sleep (60 * 2 * 1000)

    

module Program = 
    open MainFunctions.main
        [<STAThread>]
        [<EntryPoint>]
        let entrypoint argv = 
            // pulled the main thread out into its own function for tidiness
            mainThread()
            // required to be the last line of the application
            (new Application()).Run()