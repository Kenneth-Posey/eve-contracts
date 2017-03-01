namespace WPFApp

open FunEve
open FunEve.Geography
open FunEve.Contracts
open System
open System.Windows
open System.Windows.Forms

type MainViewBase = FsXaml.XAML<"views/MainView.xaml">

type MainView () as this = 
    inherit MainViewBase()
    
    // handle random contract generation
    let loadInProgressCorpContracts keyId vCode =
        Contracts.LoadCorpContracts keyId vCode
        |> List.filter 
            ( fun x -> 
                match x.Status with
                | Contracts.ApiContractStatus.InProgress -> true
                | _ -> false )
    
    let generate_click (target:MainView) (paras:RoutedEventArgs) = 
        let ran = new Random (DateTime.Now.Millisecond)

        let source = string target.sourceDropdown.Text
        let destination = string target.destinationDropdown.Text
        let length = Route.getRouteLength source destination

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


    do 
        base.generateButton.Click.Add <| generate_click this
        base.rewardText.GotFocus.Add <| handleTextClick
        base.collateralText.GotFocus.Add <| handleTextClick
        
    member this.Show() = base.Show()
    
