
// This is proof-of-concept code for using the F# from C#, so I'm putting
// the relevant snippets together in this one file

// F# code
namespace IntroDUs

module IntroDUs = 
    // This is a method of packing primitives into discriminated unions
    // and using an extension property on the DU to provide direct access
    // to the packed data. 

    // You can use the packed data in the DU for strongly typed pattern matching
    // and other useful DU features. 

    type FirstName = FirstName of string with
        member this.Value = 
            this |> (fun (FirstName x) -> x)

    type LastName = LastName of string with
        member this.Value = 
            this |> (fun (LastName x) -> x)

    type Person = {
        First: FirstName
        Last: LastName
    }

    module ExampleUse = 
        // This creates a list of strongly typed Person records 
        // with single case DU properties
        let somePeople = 
            [
                { 
                    First = FirstName "Bob"
                    Last  = LastName "Jones"
                }

                {
                    First = FirstName "Sarah"
                    Last  = LastName "Smith"
                }
            ]     
        


        type A = A of int 
        type B = B of int
        type C = C of int

        module UnionA = 
            type U = 
            | A of A
            | B of B
            | C of C

    module Union = 
        open ExampleUse.UnionA
        open ExampleUse
        type U with
            member this.Value = this |> fun x -> 
                match x with
                | U.A x -> x |> (fun (A x) -> x)
                | U.B x -> x |> (fun (B x) -> x)
                | U.C x -> x |> (fun (C x) -> x)

        let r = A 10
    
        let t = U.A r
        let z = t.Value


