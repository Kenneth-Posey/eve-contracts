namespace WPFApp

module Views = 
    open FsXaml 
    type MainViewBase = XAML<"views/MainView.xaml">
    type WelcomeViewBase = XAML<"views/Welcome.xaml">
    type ContractWriterBase = XAML<"views/ContractWriter.xaml">