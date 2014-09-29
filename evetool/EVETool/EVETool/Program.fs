// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

namespace MainModule

module Main = 

    open System
    open System.Drawing
    open System.Windows.Forms

    type MainForm() as form = 
        inherit Form()
        let mainMenu = new MainMenu()
        let mnuFile = new MenuItem()
        let mnuFileOpen = new MenuItem()
        let mnuFileSave = new MenuItem()
        let mnuFileSaveAs = new MenuItem()
        let mnuFileExit = new MenuItem()
        // The constructor simply initializes the form
        do form.InitializeForm

        // member definitions
        member this.InitializeForm =
            // Set Form attributes
            this.FormBorderStyle <- FormBorderStyle.Sizable
            this.Text <- "Fuzzy Logic Parser F# Test"
            this.Width <- 300
            this.Height <- 300
            // Declare Form events
            this.Load.AddHandler(new System.EventHandler 
                (fun s e -> this.Form_Loading(s, e)))
            this.Closed.AddHandler(new System.EventHandler 
                (fun s e -> this.Form_Closing(s, e)))

        member this.Form_Loading(sender : System.Object, e : EventArgs) =
            ()

        member this.Form_Closing(sender : System.Object, e : EventArgs) =
            ()
    
    [<STAThread>]
    do Application.Run(new MainForm())

    // [<EntryPoint>]
    // let main argv = 
    // 
    // 
    // 
    // 
    //     printfn "%A" argv
    //     0 // return an integer exit code
