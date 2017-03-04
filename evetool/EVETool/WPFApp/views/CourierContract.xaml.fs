namespace WPFApp

open System
open System.Windows

type CourierContractBase = FsXaml.XAML<"views/CourierContract.xaml">
type CourierContract() as this = 
    inherit CourierContractBase()



