namespace Fluke

module UI =
    open Common

    let formattedPrint message = 
        let msg = match message with 
            | Ok ok -> (unwrapMessage ok)
            | Error (e: System.Exception) -> e.Message
        printfn "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\
            %s\n\
            ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" msg

