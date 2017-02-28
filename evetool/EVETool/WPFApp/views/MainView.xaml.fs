namespace WPFApp.Views

open System
open System.Windows
open System.Windows.Forms
open FunEve

type MainView () as this =     
    // inherit MainViewBase ()
    let generate_click (target:MainViewBase) (paras:RoutedEventArgs) = 
        let ran = new Random (DateTime.Now.Millisecond)

        let source = string target.sourceDropdown.Text
        let destination = string target.destinationDropdown.Text
        let length = Geography.Route.getRouteLength source destination

        // 750k - 1250k per jump 
        let reward = ran.Next(750, 1250) * 1000 * length
        // 850m - 999m collateral
        let collateral = ran.Next(850, 999) * 1000000

        target.rewardText.Text <- string reward
        target.collateralText.Text <- string collateral
        ()

    let setClipboard text = 
        Clipboard.SetText text
        
    let handleTextClick (paras:RoutedEventArgs) =         
        setClipboard (paras.OriginalSource :?> System.Windows.Controls.TextBox).Text
        
    let HookManager_Click (args:Forms.MouseEventArgs) = 
        let var = args.Button
           
        printfn "%A" <| args.Button.ToString()
        ()
    
    let mutable window = new MainViewBase()
    member this.Window with
        get () = window
        and set (value) = window <- value

    member this.setup () =
        window.generateButton.Click.Add <| generate_click window
        window.rewardText.GotFocus.Add <| handleTextClick
        window.collateralText.GotFocus.Add <| handleTextClick

        ()    
    
