namespace WPFApp

open System
open System.Windows

open FsXaml
open ViewModule
open ViewModule.FSharp
open ViewModule.Validation.FSharp

module CourierContractFunctions =             
    open System.Windows.Forms
    open System.Windows.Controls
    open WPFApp.MainFunctions
        
    type SourceLocations = 
        | Osmon
        | Gekutami
        | Perimeter
        | Jita

    let sourceString = function 
        | Gekutami -> "Gekutami"
        | Osmon -> "Osmon"
        | Perimeter -> "Perimeter"
        | Jita -> "Jita"
    
    let matchSource input =
        if input = "Osmon" then Osmon
        else if input = "Gekutami" then Gekutami
        else if input = "Perimeter" then Perimeter
        else Jita

    type DestinationLocations = 
        | Osmon
        | Perimeter
        | Jita
    
    let destinationString = function
        | Osmon -> "Osmon"
        | Perimeter -> "Perimeter"
        | Jita -> "Jita"
        
    let matchDestination input = 
        if input = "Osmon" then Osmon
        else if input ="Perimeter" then Perimeter
        else Jita

    type Contents = 
        | CompGlaze
        | WhiteGlaze
        | NitroIsotopes
        | HeavyWater
        | LiquidOzone
        | StrontClathrates
    
    let contentsString = function
        | CompGlaze -> "Comp Glaze"
        | WhiteGlaze -> "White Glaze"
        | NitroIsotopes -> "Nitro Isotopes"
        | HeavyWater -> "Heavy Water"
        | LiquidOzone -> "Liquid Ozone"
        | StrontClathrates -> "Stront Clathrates"
        
    let matchContents input =     
        if input = "Comp Glaze" then CompGlaze
        else if input = "White Glaze" then WhiteGlaze
        else if input = "Nitro Isotopes" then NitroIsotopes
        else if input = "Heavy Water" then HeavyWater
        else if input = "Liquid Ozone" then LiquidOzone
        else StrontClathrates

    let loadContractInfo (source) (destination) (contents) (isPrivate) =      
        let numberOfJumps = FunEve.Geography.Route.getRouteLength source destination  
        let des = matchDestination(destination)
        let cont = matchContents(contents)

        {
            Message = 
                match isPrivate with
                | true -> ""
                | false -> "We pay for fast service! Join the Haulers Channel."
            Destination = 
                match des with 
                | Jita -> "Jita IV - Moon 4 - Caldari Navy"
                | Perimeter -> "Perimeter - Max Refine at Jita - Freeport"
                | Osmon -> "Osmon II - Moon 1 - Sisters of EVE Bureau"
            Reward = 
                match (float numberOfJumps) with
                | x when x < 2. -> 
                    match cont with 
                    | WhiteGlaze -> IskString "3.5m" // white glaze
                    | NitroIsotopes -> IskString "15m" // nitrogen isotopes
                    | LiquidOzone -> IskString "1.5m"  // liquid ozone
                    | HeavyWater -> IskString "3m"  // heavy water
                    | CompGlaze -> IskString "12m" // compressed white glaze
                    | StrontClathrates -> IskString "8m" // stront
                | x -> 
                    match cont with 
                    | WhiteGlaze -> IskString <| sprintf "%Am" (1.5 * x) // white glaze
                    | NitroIsotopes -> IskString <| sprintf "%Am" (5. * x) // nitrogen isotopes
                    | LiquidOzone -> IskString <| sprintf "%Am" (1.5 * x) // liquid ozone
                    | HeavyWater -> IskString <| sprintf "%Am" (2. * x) // heavy water
                    | CompGlaze -> IskString <| sprintf "%Am" (4. * x) // compressed white glaze
                    | StrontClathrates -> IskString <| sprintf "%Am" (3. * x) // stront
            Collateral = 
                match cont with 
                | WhiteGlaze -> IskString "350m" // white glaze
                | NitroIsotopes -> IskString "1.9b" // nitrogen isotopes
                | LiquidOzone -> IskString "175m"  // liquid ozone
                | HeavyWater -> IskString "687.5m"  // heavy water
                | CompGlaze -> IskString "1550m" // compressed white glaze
                | StrontClathrates -> IskString "1125m" // stront
        }
    

open CourierContractFunctions
open MainFunctions
open Gma.UserActivityMonitor
type CourierContractViewModel () as this = 
    inherit ViewModelBase ()
    
    let mutable statusMessage = "Update"
    let mutable selectedContents = ""
    let mutable selectedSource = ""
    let mutable selectedDestination = ""
    let mutable isPrivate = false

    let mutable contractInfo = {
            Message = "We pay for fast service! Join the Haulers Channel."
            Destination = "Jita IV - Moon 4 - Caldari Navy"
            Reward = IskString "9m"
            Collateral = IskString "160m"  // liquid ozone
        }
        
    // abstract later
    // 1) extract DU
    // 2) loop through extracted DU
    // 3) run string function on extracted DU values

    let sources = [
        sourceString SourceLocations.Gekutami
        sourceString SourceLocations.Jita
        sourceString SourceLocations.Osmon
        sourceString SourceLocations.Perimeter
    ]

    let destinations = [
        destinationString DestinationLocations.Jita
        destinationString DestinationLocations.Osmon
        destinationString DestinationLocations.Perimeter
    ]

    let contents = [
        contentsString Contents.CompGlaze
        contentsString Contents.HeavyWater
        contentsString Contents.LiquidOzone
        contentsString Contents.NitroIsotopes
        contentsString Contents.StrontClathrates
        contentsString Contents.WhiteGlaze
    ]

    let updateContract = 
        this.Factory.CommandSync (fun x ->                         
            (selectedSource, selectedDestination, selectedContents, isPrivate)
            |> fun (a,b,c,d) -> 
                this.ContractInfo <- CourierContractFunctions.loadContractInfo a b c d
            
            printf "Message: %A" this.ContractInfo.Message
            printf "Reward: %A" this.ContractInfo.Reward.DisplayValue
            printf "Collateral: %A" this.ContractInfo.Collateral.DisplayValue
            printf "Destination: %A" this.ContractInfo.Destination
        )        

    // this way the mutable value update when the function runs
    let keypress (args) = HookManager_KeyPress this.ContractInfo args
    do 
        HookManager.KeyPress.Add keypress

    member this.Sources with get () = sources
    member this.Destinations with get () = destinations
    member this.Contents with get () = contents

    member this.SelectedContents
        with get () = selectedContents
        and set (value) = selectedContents <- value

    member this.SelectedSource
        with get () = selectedSource
        and set (value) = selectedSource <- value

    member this.SelectedDestination
        with get () = selectedDestination
        and set (value) = selectedDestination <- value

    member this.ContractInfo 
        with get () = contractInfo
        and set (value) = contractInfo <- value

    member this.StatusMessage 
        with get () = statusMessage
        and set (value) = statusMessage <- value     
           
    member this.IsPrivate 
        with get () = isPrivate
        and set (value) = isPrivate <- value        

    member this.UpdateContractEvent = updateContract
        