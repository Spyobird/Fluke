open Fluke.UseCases
open System

let runLoop() =
    printfn "Hello from Fluke\n"
    while not doExit do
        handleUses (Console.ReadLine())

[<EntryPoint>]
let main argv =
    runLoop()
    0