namespace Fluke

module Logger =
    open Common

    let log res =
        match res.message with
        | Ok _ -> ()
        | Error e -> printfn "[ERROR] %s" (unwrapErrorMessage e)