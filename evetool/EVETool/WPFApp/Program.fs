namespace WPFApp

open System
open System.Windows
open WPFApp
open Gma.UserActivityMonitor
open MainFunctions    

module Program = 
    [<STAThread>]
    [<EntryPoint>]
    let entrypoint argv = 
        // ConsoleControl.HideConsole() |> ignore

        HookManager.KeyPress.Add HookManager_KeyPress

        // (new MainView()).Show()

        // required to be the last line of the application
        (new Application()).Run()

        