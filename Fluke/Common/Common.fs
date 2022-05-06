namespace Fluke

module Common =
    type SuccessMessage = SuccessMessage of string

    type ErrorMessage =
        | RequestError of string
        | GenericError of string

    type Message = Result<SuccessMessage, ErrorMessage>

    type Request = {
        header: string
        body: string option
    }

    type Response = {message: Message}

    let success: string -> Message = fun msg -> Ok (SuccessMessage msg)

    let unwrapSuccessMessage (SuccessMessage str) = str

    let unwrapErrorMessage (err: ErrorMessage) =
        match err with
        | RequestError str -> str
        | GenericError str -> str

    let value (msg: Message) =
        match msg with
        | Ok s -> unwrapSuccessMessage s
        | Error e -> unwrapErrorMessage e

    let trimString (str: string) = str.Trim()

    let (>=>) f1 f2 = f1 >> Result.bind f2
