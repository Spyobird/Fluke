namespace Fluke

module Parser =
    open Common

    exception ParseError of string

    let parse (input: string) =
        let trim = input.Trim()
        let splitLine = trim.Split([|' '|], 2)
        try
            match splitLine.[0] with
            | "todo" -> Ok (Todo splitLine.[1])
            | "event" -> Ok (Event splitLine.[1])
            | "deadline" -> Ok (Deadline splitLine.[1])
            | "list" -> Ok List
            | "echo" -> Ok (Echo splitLine.[1])
            | "bye" -> Ok Bye
            | _ -> Error (ParseError "Parse Error")
        with
            | e -> Error (e)
