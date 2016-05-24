open CardinalityEstimation
open System
open System.Diagnostics

[<EntryPoint>]
let main argv = 
    
    let source = 
        Array.init 1000 <| fun _ -> Guid.NewGuid().ToString() // ToByteArray()
        //Array.init 10000 <| fun _ -> Guid.NewGuid().ToByteArray()
        |> Array.replicate 50000
        |> Array.concat
    
    printfn "Source count = %d" source.Length 
    
    let estimator = CardinalityEstimator()
    let sw = Stopwatch.StartNew()
    for x in source do estimator.Add x
    let count = estimator.Count()
    sw.Stop()
    printfn "Count = %d, %O elapsed." count sw.Elapsed
    Console.ReadKey() |> ignore
    0
