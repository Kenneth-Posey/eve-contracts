namespace FunEve.CharacterDomain
open FunEve.Base.Types

module Implant = 
    
    type Slot = 
    | Slot0
    | Slot1
    | Slot2
    | Slot3
    | Slot4
    | Slot5
    | Slot6
    | Slot7
    | Slot8
    | Slot9
    | Slot10

    type EffectStrength = EffectStrength of single with
        member this.Value = 
            this |> (fun (EffectStrength x) -> x)

    type Attribute = {
        // Name : Name
        TypeId : TypeId
        // Attributes : Attribute list
        Effects : ( EffectStrength * Attribute ) list
    }

    type Implant = {
        Name : Name
        Slot : Slot
        TypeId : TypeId
        Multiplier : Multiplier
        Attributes : Attribute list
    }

