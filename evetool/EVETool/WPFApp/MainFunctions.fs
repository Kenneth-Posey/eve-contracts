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
        Thread.Sleep 10
        KeyboardControl.KeyboardEvent (byte key) (byte 0x2) 0 0 // keyup

    let sendKeys keys = 
        SendKeys.SendWait keys
        SendKeys.Flush ()

    let floatParse (x:string) multiplier = 
        let result = ref 0.
        match Double.TryParse(x, result) with
        | true -> int (!result * (float multiplier))
        | false -> 0

    type IskString = IskString of string with
        member this.Value = this |> (fun (IskString x) -> 
            match x.Trim() with
            | x when x.EndsWith("b") -> floatParse (x.TrimEnd('b')) 1000000000
            | x when x.EndsWith("m") -> floatParse (x.TrimEnd('m')) 1000000
            | x when x.EndsWith("k") -> floatParse (x.TrimEnd('k')) 1000
            | x when x.Length > 0 -> floatParse x 1
            | _ -> 0)
        member this.DisplayValue = this |> (fun (IskString x) -> x)
            
    type CourierContractInfo = {
        Destination: string
        Collateral: IskString
        Reward: IskString
        Message: string
        }

    let WriteContract (contract:CourierContractInfo) = 
        step sendKeys contract.Destination
        step sendKeys "{TAB}"
        Thread.Sleep 1000
        step sendKeys "{TAB}"
        step sendKeys (string contract.Reward.Value)
        step sendKeys "{TAB}"
        step sendKeys (string contract.Collateral.Value)
        repeatStep 4 sendKeys "{TAB}"
        step sendKeys contract.Message

    let WriteCourierContract () = 
        WriteContract {
            Message = "We pay for fast service! Join the Haulers Channel."
            Destination = "Perimeter - Max Refine at Jita - Freeport"
            // Destination = "Jita IV - Moon 4 - Caldari Navy"
            Reward = IskString "3m"
            Collateral = IskString "275m"   // white glaze
            // Collateral = IskString "1.75b" // nitrogen isotopes
            // Collateral = IskString "175m"  // liquid ozone
            // Collateral = IskString "1125m" // stront
            // Collateral = IskString "750m"  // heavy water
            // Collateral = IskString "1550m" // compressed white glaze
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
    
