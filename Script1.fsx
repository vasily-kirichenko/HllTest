#r @"packages\murmurhash\lib\net45\MurmurHash.dll"
#r @"packages\CardinalityEstimation\lib\net45\CardinalityEstimation.dll"

open CardinalityEstimation
open System

let source = 
    Array.init 50000 <| fun _ -> Guid.NewGuid().ToByteArray()
    |> Array.replicate 1000
    |> Array.concat

source.Length 

let estimator = CardinalityEstimator()

for x in source do estimator.Add x

estimator.Count()