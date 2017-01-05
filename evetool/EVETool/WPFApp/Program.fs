open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open FsXaml

module main =
    open WPFApp.Views    
    let mainThread () = 
        let win = new MainView()
        win.Show()

        ()

    [<STAThread>]
    [<EntryPoint>]
    let entrypoint argv = 
        // pulled the main thread out into its own function for tidiness
        mainThread()
        // required to be the last line of the application
        (new Application()).Run()