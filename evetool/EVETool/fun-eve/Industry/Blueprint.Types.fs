namespace FunEve.IndustryDomain.Blueprint

module Types = 
    open FunEve.Base.Types

    type Probability = Probability of single with
        member this.Value = 
            this |> (fun (Probability x) -> x)
            
    type ReqSkill = ReqSkill of Level * TypeId with
        member this.Value = 
            this |> (fun (ReqSkill (s, t)) -> s, t)
                        
    type MfgMaterial = MfgMaterial of (Qty * TypeId) list with
        member this.Value = 
            this |> (fun (MfgMaterial x) -> x)

    type MfgProduct = MfgProduct of (Qty * TypeId * Probability option) list with
        member this.Value =     
            this |> (fun (MfgProduct x) -> x)

    type MfgSkill = MfgSkill of ReqSkill list with
        member this.Value = 
            this |> (fun (MfgSkill x) -> x)
    
    type RunLimit = RunLimit of int with
        member this.Value =
            this |> (fun (RunLimit x) -> x)
            
    type MaterialEfficiency = MaterialEfficiency of int with
        member this.Value =
            this |> (fun (MaterialEfficiency x) -> x)

    type TimeEfficiency = TimeEfficiency of int with
        member this.Value =
            this |> (fun (TimeEfficiency x) -> x)

                        
    type Activities = 
    | Copying of Time
    | ResearchMaterial of Time
    | ResearchTime of Time
    | Manufacturing of Time * MfgMaterial * MfgProduct * MfgSkill
    | Invention of Time * MfgMaterial * MfgProduct * MfgSkill

    type CopyType = 
    | Original
    | Copy
    | InventedT2
    | InventedT3
