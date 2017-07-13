namespace DoNotUse

// http://www.codemag.com/article/1707051
module TestModule = 
    type CoordinatorMessage =
    | Job of int
    | Ready
    | RequestJob of AsyncReplyChannel<int>

    type SortDataMessage =
    | Agent1 of int
    | Agent2 of int
    | Agent3 of int
    | Agent4 of int

    let vals1 = new ResizeArray<int*int>()
    let vals2 = new ResizeArray<int*int>()
    let vals3 = new ResizeArray<int*int>()
    let vals4 = new ResizeArray<int*int>()

    let SortData =
        MailboxProcessor<SortDataMessage>.Start(fun inbox ->
            let rec loop () =
                async {
                    let! message = inbox.Receive()
                    match message with
                    | Agent1 w -> vals1.Add(vals1.Count,w)
                    | Agent2 x -> vals2.Add(vals2.Count,x)
                    | Agent3 y -> vals3.Add(vals3.Count,y)
                    | Agent4 z -> vals4.Add(vals4.Count,z)
                    return! loop ()
                }
            loop ()
            )

    let Coordinator =
        MailboxProcessor<CoordinatorMessage>.Start(fun inbox ->
            let queue = new System.Collections.Generic.Queue<int>()
            let mutable count = 0
            let rec loop () =
                async {
                    while count < 4 do
                        do! inbox.Scan (function
                            | Ready -> Some(async {count<-count+1})
                            | Job l -> None
                            | RequestJob r -> None)
                    let! message = inbox.Receive()
                    match message with
                    | Job length -> queue.Enqueue length
                    | RequestJob replyChannel ->
                        replyChannel.Reply <| queue.Dequeue()
                    | Ready -> ()      
                    return! loop ()
                }
            loop ()
            )
    
    let worker whichagent =
        MailboxProcessor<bool>.Start(fun inbox ->
            Coordinator.Post Ready
            let rec loop () = 
                async {
                        let! length = Coordinator.PostAndAsyncReply (fun reply -> RequestJob reply)
                        let byAgent =
                            match whichagent with
                            | 1 -> Agent1 length
                            | 2 -> Agent2 length
                            | 3 -> Agent3 length
                            | 4 -> Agent4 length
                            | _ -> failwith "Unknown agent"
        
                        SortData.Post byAgent              
                        do! Async.Sleep length
                        return! loop ()
                    }
            loop ()
            )






    ()

