open System
open System.Windows
open System.Windows.Data
open System.Windows.Input

open FSharp.Desktop.UI

open FsXaml

// This is a port of the FSharp.Desktop.UI NumericUpDown sample
// which uses FsXaml to load the UI instead of building
// via code directly - Based on code from:
//     http://fsprojects.github.io/FSharp.Desktop.UI/tutorial_numeric_up_down.html
//     https://github.com/fsprojects/FSharp.Desktop.UI/blob/master/samples/NumericUpDown/Program.fs

type App = FsXaml.XAML<"App.xaml">
// Pass true to expose all named properties as public properties of MainWindow
type MainWindow = FsXaml.XAML<"MainWindow.xaml", true>

[<AbstractClass>]
type MainModel () = 
    inherit Model ()
    abstract Value: int with get, set

type TestEvents = One | Two | Three

type MainModelView (root:MainWindow) =
    inherit View<TestEvents, MainModel, Window>(root.Root)

    override this.EventStreams = []

    override this.SetBindings model =
        let root = MainWindow(this.Root)
        // Binding.OfExpression
        //     <@
        //         root.TestTextbox.Text <- coerce "10"
        //     @>
        ()

let MainEventHandler event (model:MainModel) =
    match event with
    | One -> ()
    | Two -> ()
    | Three -> ()

let controller = Controller.Create MainEventHandler


[<STAThread>]
[<EntryPoint>]
let main _ = 
    let model = MainModel.Create ()

    let app = App().Root
    let view = MainModelView(MainWindow())

    let mvc = Mvc(model, view, controller)
    use __ = mvc.Start ()

    app.Run(view.Root)