namespace WPFApp

open System
open System.Threading
open System.Windows.Forms
open Gma.UserActivityMonitor
open FunEve
open FunEve.Utility
open FunEve.Utility.DllImports

module MainFunctions = 
    // how to get an enum value
    // let getEnum<'T> (x:char) = enum<'T>(int32 x)

    let step inFunction data =
        Thread.Sleep 100 
        inFunction data
        
    let repeat times inFunction data = 
        for iter in [1 .. times] do
            inFunction data
            
    let repeatStep times inFunction data = 
        for iter in [1 .. times] do
            step inFunction data

    let pressKey key =         
        KeyboardControl.KeyboardEvent (byte key) 0uy 0 0 // keydown
        Thread.Sleep 20
        KeyboardControl.KeyboardEvent (byte key) (byte 0x2) 0 0 // keyup

    let sendKeys keys = 
        SendKeys.SendWait keys
        SendKeys.Flush ()

    type CourierContractInfo = {
        Destination: string
        Collateral: int
        Reward: int
        Message: string
        }

    let WriteContract (contract:CourierContractInfo) = 
        step sendKeys contract.Destination
        step sendKeys "{TAB}"
        Thread.Sleep 1000
        step sendKeys "{TAB}"
        step sendKeys (string contract.Reward)
        step sendKeys "{TAB}"
        step sendKeys (string contract.Collateral)
        repeatStep 4 sendKeys "{TAB}"
        step sendKeys contract.Message

    let WriteCourierContract () = 
        WriteContract {
            Message = "We pay for fast service! Join the Haulers Channel."
            // Destination = "Perimeter - Max Refine at Jita - Freeport"
            Destination = "Jita IV - Moon 4 - Caldari Navy"
            Collateral = 3000000
            Reward = 275000000   // white glaze
            // Reward = 1750000000 // nitrogen isotopes
            // Reward = 175000000  // liquid ozone
            // Reward = 1125000000 // stront
            // Reward = 950000000  // heavy water
            // Reward = 1550000000 // compressed white glaze
        }
        
    let HookManager_KeyPress (args:KeyPressEventArgs) =
        // let keyEnum = getEnum args.KeyChar        
        // let shiftstate = KeyboardControl.GetKeyState(GlobalHook.VK_SHIFT) = int16 0
        // let altstate = KeyboardControl.GetKeyState(GlobalHook.VK_LCONTROL) = int16 0
        // let ctrlstate = KeyboardControl.GetKeyState(GlobalHook.VK_LALT) = int16 0
        
        printfn "Pressed key %A time %A" <|| (args.KeyChar, DateTime.Now)
        let handled = 
            match args.KeyChar with
            | x when x = '`' -> 
                WriteCourierContract()
                true
            | _ -> 
                false
                        
        printfn "Handled? %A" handled
        args.Handled <- handled
        ()
    
        // let apikeys = BadNewbies.ApiKeys
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
    
