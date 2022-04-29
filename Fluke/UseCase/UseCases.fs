namespace Fluke

module UseCases =
    open Common
    open System

    let mutable doExit = false;

    let echo msg = createMessage msg

    let bye() =
        doExit <- true
        createMessage "Bye"

    let execute cmd =
        match cmd with
            | Echo msg -> echo msg
            | Bye -> bye()

    let handleUses input =
        Parser.parse input
        |> Result.map execute
        |> UI.formattedPrint
       