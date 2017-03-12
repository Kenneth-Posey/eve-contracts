namespace WPFApp

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
        
