namespace FunEve.Base

module Types = 
    
    // General Properties
    type TypeId = TypeId of int

    type Name = Name of string with
        member this.Value = 
            this |> (fun (Name x) -> x)

    type Volume = Volume of single
    
    type Qty = Qty of int

    type Price = Price of single with
        member this.Value = 
            this |> (fun (Price x) -> x)

    type Multiplier = Multiplier of single 
                
    type Time = Time of int 
                
    type Level = Level of int 