namespace FunEve.IndustryDomain.Blueprint

module Parser = 
    open System.Text.RegularExpressions
    type Patterns () = 
        // Group 1: blueprint typeid        ^([0-9]{1,7}:\n)
        // Require line-start, then numbers for typeid, then colon, then newline
        // Group 2: blueprint contents      ((?:^ {2}[\w- :]*\n)*) 
        // Require line-start, then two spaces, then text, then newline, then repeat
        // Captures all the *indented* text underneath a typeid and stops at the next typeid
        static member Root = new Regex @"^([0-9]{1,7}:\n)((?: {2}[\w- :]*\n)*)"

        // Group 1: available activities
        static member Activities = new Regex @"^(?: {2}[actives]*:\n)([\w- :\n]*?\n)(?: {2}[a-z])"
        static member Copying = new Regex @"^(?: {4}[copying]*:\n)([\w- :\n]*?\n)(?: {4}[a-z])"
        static member Manufacturing = new Regex @"^(?: {4}[manufctring]*:\n)([\w- :\n]*?\n)(?: {4}[a-z])"
        static member ResvearchMaterial = new Regex @"^(?: {4}[resarchmtil_]*:\n)([\w- :\n]*?\n)(?: {4}[a-z])"
        static member ResearchTime = new Regex @"^(?: {4}[research_time]*:\n)([\w- :\n]*?\n)(?: {2}[a-z])"
        static member Materials = new Regex @"^(?: {6}[materils]*:\n)([\w- :\n]*?\n)(?: {6}[a-z])"
        static member Skills = new Regex @"^(?: {6}[skil]*:\n)([\w- :\n]*?\n)(?: {6}[a-z])"
        static member Products = new Regex @"^(?: {6}[products]*:\n)([\w- :\n]*?\n)(?: {6}[a-z])"
        static member Time = new Regex @"^(?: {6}time: )([0-9]*?)\n"
        static member Quantity = new Regex ""
        static member TypeId = new Regex ""
        static member Limit = new Regex ""
        static member Probability = new Regex ""
    


    ()
