﻿namespace WPFApp

open System
open System.Windows
open WPFApp

module Program = 
    [<STAThread>]
    [<EntryPoint>]
    let entrypoint argv = 
        // ConsoleControl.HideConsole() |> ignore

        let testval = FunEve.MarketDomain.MarketXmlApi.formApiUrl ()

        (new MainView()).Show()

        // required to be the last line of the application
        let app = new System.Windows.Application()
        app.Run()

        