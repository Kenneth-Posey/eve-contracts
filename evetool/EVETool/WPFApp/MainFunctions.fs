namespace WPFApp

open System
open System.Threading
open System.Windows.Forms
open Gma.UserActivityMonitor
open FunEve
open FunEve.Utility
open FunEve.Utility.DllImports

module MainFunctions = 
    let floatParse (x:string) (multiplier:int) = 
        let result = ref 0.
        match Double.TryParse(x, result) with
        | true -> int (!result * (float multiplier))
        | false -> 0

    type IskString = IskString of string with
        member this.Value = this |> (fun (IskString x) -> 
            match x.Trim() with
            | x when x.EndsWith("k") -> floatParse (x.TrimEnd('k')) 1000
            | x when x.EndsWith("m") -> floatParse (x.TrimEnd('m')) 1000000
            | x when x.EndsWith("b") -> floatParse (x.TrimEnd('b')) 1000000000
            | x when x.Length > 0 -> floatParse x 1
            | _ -> 0)
        member this.DisplayValue = this |> (fun (IskString x) -> x)
                    
    type CourierContractInfo = {
        Destination: string
        Collateral: IskString
        Reward: IskString
        Message: string
        }

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
        
    let WriteCourierContract (contract:CourierContractInfo) = 
        step sendKeys contract.Destination
        step sendKeys "{TAB}"
        Thread.Sleep 1000
        step sendKeys "{TAB}"
        step sendKeys (string contract.Reward.Value)
        step sendKeys "{TAB}"
        step sendKeys (string contract.Collateral.Value)
        repeatStep 4 sendKeys "{TAB}"
        step sendKeys contract.Message
        
    let HookManager_KeyPress (input:CourierContractInfo) (args:KeyPressEventArgs)  =        
        printfn "Pressed key %A time %A" <|| (args.KeyChar, DateTime.Now)
        let handled = 
            match args.KeyChar with
            | x when x = '`' -> 
                WriteCourierContract (input)
                true
            | _ -> 
                false
                        
        printfn "Handled? %A" handled
        args.Handled <- handled
        ()
    
