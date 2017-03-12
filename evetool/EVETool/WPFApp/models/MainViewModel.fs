namespace WPFApp

open System
open System.Windows

open FsXaml
open ViewModule
open ViewModule.FSharp
open ViewModule.Validation.FSharp

module MainViewModelFunctions =             
    open System.Windows.Forms
    open System.Windows.Controls
    
    let setClipboard text = 
        Clipboard.SetText text
        
    let handleTextClick (paras:RoutedEventArgs) =         
        setClipboard (paras.OriginalSource :?> TextBox).Text
        
    let HookManager_Click (args:Forms.MouseEventArgs) = 
        let var = args.Button
           
        printfn "%A" <| args.Button.ToString()
        ()

open MainViewModelFunctions
type MainViewModel () = 
    inherit ViewModelBase ()
    
    let mutable testValue = "ttt"
    member this.TestValue 
        with get () = testValue
        and set (value) = testValue <- value