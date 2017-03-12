namespace WPFApp

open System
open System.Windows
open System.Windows.Forms
open FunEve.Geography

type ContractMonitorBase = FsXaml.XAML<"views/ContractMonitor.xaml">
type ContractMonitor() as this = 
    inherit ContractMonitorBase()

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

    // handle random contract generation
    // let loadInProgressCorpContracts keyId vCode =
    //     Contracts.LoadCorpContracts keyId vCode
    //     |> List.filter 
    //         ( fun x -> 
    //             match x.Status with
    //             | Contracts.ApiContractStatus.InProgress -> true
    //             | _ -> false )
        
    let setClipboard text = 
        Clipboard.SetText text
        
    let handleTextClick (paras:RoutedEventArgs) =         
        setClipboard (paras.OriginalSource :?> TextBox).Text
        
    let generate_click (view:ContractMonitorBase) (paras:RoutedEventArgs) = 
        let ran = new Random (DateTime.Now.Millisecond)

        let source = string view.sourceDropdown.Text
        let destination = string view.destinationDropdown.Text
        let length = Route.getRouteLength source destination

        // 750k - 1250k per jump 
        let reward = ran.Next(750, 1250) * 1000 * length
        // 850m - 999m collateral
        let collateral = ran.Next(850, 999) * 1000000

        view.rewardText.Text <- string reward
        view.collateralText.Text <- string collateral
        ()

    do
        base.generateButton.Click.Add <| generate_click (this :> ContractMonitorBase) // base.sourceDropdown base.destinationDropdown base.rewardText base.collateralText
        base.rewardText.GotFocus.Add <| handleTextClick
        base.collateralText.GotFocus.Add <| handleTextClick
        

        ()
    


