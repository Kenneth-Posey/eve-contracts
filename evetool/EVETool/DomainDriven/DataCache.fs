namespace EveOnline

module DataCache = 
    let memoize f =
        let cache = ref Map.empty
        fun x ->
            match (!cache).TryFind(x) with
            | Some res -> res
            | None ->
                 let res = f x
                 cache := (!cache).Add(x,res)
                 res

    open System.Collections.Generic
    let memoize2 f = 
        let cache = Dictionary<_, _>()
        fun x -> 
            let mutable ok = Unchecked.defaultof<_>
            let res = cache.TryGetValue(x, &ok)
            if ok then res 
            else let res = f x
                 cache.[x] <- res
                 res