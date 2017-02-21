namespace FunEve.Industry

open FunEve.ProductDomain.Types
open FunEve.CharacterDomain
open FunEve.CharacterDomain.Character
open FunEve.CharacterDomain.Skill


module Reprocess = 
    
    let ReprocessRate (stationRate:double) (character:Character) = 
        
        let refine = character.Skills |> List.find (fun (x:Skill) -> ("Refine" = x.Name.Value))
        
        let reprocessRate = 0

        reprocessRate
