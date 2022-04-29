open System

let fluke = "Fluke"

let mutable exit = false

let formattedPrint message = 
    printfn "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\
        %s\n\
        ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" message

let echo message =
    formattedPrint message

[<EntryPoint>]
let main argv =
    printfn "Hello from %s\n" fluke
    while not exit do
        let input = Console.ReadLine()
        match input with
        | "bye" -> exit <- true
        | _ -> echo input
    0