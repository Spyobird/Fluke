namespace Fluke

module Application =
    open Common
    open DomainTypes

    type Adapter = Command -> State -> StateResult

    type API() =

        let mutable state = State.initialState

        let updateState newState =
            state <- newState

        let createResponse result =
            match result with
            | Ok _ -> {message = success "Ok"}
            | Error err -> {message = Error err}

        member this.Execute (fn: Adapter) (req: Request) =
            match req.header with
            | "todo" ->
                match req.body with
                | Some str ->
                    let task = Task.todo str
                    Ok (Add task)
                | None -> Error (RequestError "Description cannot be empty")
            | "list" -> Ok List
            | "bye" -> Ok Bye    
            | "" -> Ok Empty
            | _ -> Error (RequestError ("Unknown request " + req.header)) // TODO: change to error type
            |> Result.map fn
            |> Result.bind (fun f -> f state)
            |> Result.map updateState
            |> createResponse

    let (>.<) (a1: Adapter) (a2: Adapter) = fun c -> (a1 c) >=> (a2 c)
                