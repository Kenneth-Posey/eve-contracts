namespace WPFApp

open System
open System.Windows
open System.Windows.Forms
open FunEve.Geography

type ContractMonitorBase = FsXaml.XAML<"views/ContractMonitor.xaml">
type ContractMonitor() as this = 
    inherit ContractMonitorBase()
    
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
    


