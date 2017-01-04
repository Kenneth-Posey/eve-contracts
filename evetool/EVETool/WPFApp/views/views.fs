namespace WPFApp

module internal Constants = 
    [<Literal>]
    let MainWindowLocation = "views/main.xaml"
    [<Literal>]
    let WelcomeWindowLocation = "views/welcome.xaml"


module Views = 
    open FsXaml
    type MainView = XAML<Constants.MainWindowLocation>
    type WelcomeView = XAML<Constants.WelcomeWindowLocation>