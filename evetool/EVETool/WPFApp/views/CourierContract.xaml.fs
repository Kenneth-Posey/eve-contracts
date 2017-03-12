namespace WPFApp

open System
open System.Windows
open WPFApp.CourierContractFunctions

type CourierContractBase = FsXaml.XAML<"views/CourierContract.xaml">
type CourierContract() as this = 
    inherit CourierContractBase()

    do    
        ()
    


