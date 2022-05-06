namespace Fluke

module Run =
    open Application
    open DomainTypes
    open System

    let mutable doExit = false

    let exit() = doExit <- true
   
    let app = API()

    let add task state = 
        State.add task state

    let coreFn: Adapter = fun command state ->
        match command with
        | Add task -> Ok (add task state)
        | _ -> Ok state

    let handleExit command state =
        match command with
        | Bye -> 
            exit()
            Ok state
        | _ -> Ok state

    let mainFn =
        coreFn
        >.< Adapters.PersistenceAdapter
        >.< Adapters.UiAdapter
        >.< handleExit

    let runLoop() =
        printfn "Hello from Fluke\n"
        while not doExit do
            Parser.parse (Console.ReadLine())
            |> app.Execute mainFn
            |> Logger.log