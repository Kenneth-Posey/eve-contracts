namespace FunEve.CharacterDomain
open FunEve.Base.Types

module Skill = 

    type SkillMultiplier = SkillMultiplier of int with
        member this.Value = 
            this |> (fun (SkillMultiplier x) -> x)

    type SkillPoint = SkillPoint of int with
        member this.Value = 
            this |> (fun (SkillPoint x) -> x)
    
    type Skill = {
        Name : Name
        Multiplier : SkillMultiplier
        TypeId : TypeId
        CurrentSP: SkillPoint
        Level : Level
        RequiredFor: Skill list
        Prerequisite: Skill list
    }

