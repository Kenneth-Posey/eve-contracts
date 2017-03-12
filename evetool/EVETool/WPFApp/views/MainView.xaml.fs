namespace WPFApp.Views

open FunEve
open FunEve.Geography
open FunEve.Contracts
open System
open System.Windows

type MainViewBase = FsXaml.XAML<"views/MainView.xaml">

open MainViewModelFunctions
type MainView () as this = 
    inherit MainViewBase()        

    member this.Show() = base.Show()    
        

    member this.setup () =
        window.generateButton.Click.Add <| generate_click window
        window.rewardText.GotFocus.Add <| handleTextClick
        window.collateralText.GotFocus.Add <| handleTextClick

        ()    
    
