namespace FunEve.CharacterDomain
open Skill
open Implant

module Character = 
    
    type Attribute = Attribute of int with
        member this.Value = 
            this |> (fun (Attribute x) -> x)

    type SkillAttribute = 
    | Charisma
    | Intelligence
    | Memory
    | Perception
    | Willpower

    type Charisma = Charisma of Attribute with
        member this.Value = 
            this |> (fun (Charisma (Attribute x)) -> x)
            
    type Intelligence = Intelligence of Attribute with
        member this.Value = 
            this |> (fun (Intelligence (Attribute x)) -> x)

    type Memory = Memory of Attribute with
        member this.Value = 
            this |> (fun (Memory (Attribute x)) -> x)

    type Perception = Perception of Attribute with
        member this.Value = 
            this |> (fun (Perception (Attribute x)) -> x)

    type Willpower = Willpower of Attribute with
        member this.Value = 
            this |> (fun (Willpower (Attribute x)) -> x)

    type CharacterAttributes = {
        Charisma : Charisma
        Intelligence : Intelligence
        Memory : Memory
        Perception : Perception
        Willpower : Willpower
    }

    type Character = {
        Skills : Skill list
        Implants : Implant list
        Attributes : CharacterAttributes
    }

