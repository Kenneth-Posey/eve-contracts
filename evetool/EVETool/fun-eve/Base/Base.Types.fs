namespace FunEve.Base

module Types = 
    
    // General Properties
    type TypeId = TypeId of int with
        member this.Value = 
            this |> (fun (TypeId x) -> x)

    type Name = Name of string with
        member this.Value = 
            this |> (fun (Name x) -> x)

    type Volume = Volume of single with
        member this.Value = 
            this |> (fun (Volume x) -> x)
    
    type Qty = Qty of int with
        member this.Value = 
            this |> (fun (Qty x) -> x)

    type Price = Price of single with
        member this.Value =     
            this |> (fun (Price x) -> x)

    type Multiplier = Multiplier of single with
        member this.Value =     
            this |> (fun (Multiplier x) -> x)
                
    type Time = Time of int with 
        member this.Value = 
            this |> (fun (Time x) -> x)
                
    type Level = Level of int with
        member this.Value = 
            this |> (fun (Level x) -> x)