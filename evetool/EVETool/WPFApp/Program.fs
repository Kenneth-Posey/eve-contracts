namespace WPFApp

open System
open System.Threading
open System.Windows
open Gma.UserActivityMonitor
open FunEve
open FunEve.Utility
open FunEve.Utility.DllImports

module MainFunctions = 
    // open this inside the module
    // top prevent namespace issues
    open System.Windows.Forms
    // how to get an enum value
    // let getEnum<'T> (x:char) = enum<'T>(int32 x)

    let step inFunction data =
        Thread.Sleep 50 
        inFunction data
        
    let repeat times inFunction data = 
        for iter in [1 .. times] do
            inFunction data
            
    let repeatStep times inFunction data = 
        for iter in [1 .. times] do
            step inFunction data

    let pressKey key =         
        KeyboardControl.KeyboardEvent (byte key) 0uy 0 0 
        Thread.Sleep 30
        KeyboardControl.KeyboardEvent (byte key) (byte 0x2) 0 0

    let sendKey keys = 
        SendKeys.SendWait keys
        SendKeys.Flush ()

    let HookManager_KeyPress (args:Forms.KeyPressEventArgs) =
        // let keyEnum = getEnum args.KeyChar        
        // let shiftstate = KeyboardControl.GetKeyState(GlobalHook.VK_SHIFT) = int16 0
        // let altstate = KeyboardControl.GetKeyState(GlobalHook.VK_LCONTROL) = int16 0
        // let ctrlstate = KeyboardControl.GetKeyState(GlobalHook.VK_LALT) = int16 0
        
        printfn "Pressed key %A time %A" <|| (args.KeyChar, DateTime.Now)
        let handled = 
            match args.KeyChar with
            | x when x = '`' -> 
                // step sendKey "Perimeter - Max Ice Refine @ Jita - Public"
                step sendKey "Jita IV - Moon 4 - Caldari Navy"
                step sendKey "{TAB}"
                Thread.Sleep 1000
                step sendKey "{TAB}"
                step sendKey "24000000"
                step sendKey "{TAB}"
                step sendKey "1750000000"
                repeatStep 4 sendKey "{TAB}"
                step sendKey "We pay for fast service! Join the Haulers Channel."
                true
            | _ -> 
                false
                        
        printfn "Handled? %A" handled
        args.Handled <- handled
        ()
    
    let mainThread () = 
        let win = new MainView ()        
        let ran = new Random (DateTime.Now.Millisecond)
        let apikeys = BadNewbies.ApiKeys

        HookManager.KeyPress.Add HookManager_KeyPress

        // let n = WebServers.start ()
        win.Show()
        ()

        // let mutable BREAK = false        
        // while not BREAK do
        //     let apikey = apikeys.[ran.Next(0, apikeys.Length - 1)]
        //     let contracts = loadInProgressCorpContracts apikey.keyId apikey.vCode
        // 
        //     match contracts.Length with
        //     | x when x > 0 -> 
        //         win.statusLabel.Content <- x.ToString() + "x CONTRACTS"
        //         // win.Activate () |> ignore
        //         win.Show ()
        //     | _ -> 
        //         win.Hide ()
        //         Thread.Sleep (ran.Next(30, 180) * 1000)
    
    
module Program = 
    open MainFunctions
    [<STAThread>]
    [<EntryPoint>]
    let entrypoint argv = 
        // hide console
        // ConsoleControl.HideConsole() |> ignore
        // pulled the main thread out into its own function for tidiness
        mainThread()

        // required to be the last line of the application
        (new Application()).Run()

        