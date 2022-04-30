namespace Fluke

module Parser =
    open Common

    exception ParseError of string

    let parse (input: string) =
        let trim = input.Trim()
        let splitLine = trim.Split([|' '|], 2)
        match splitLine.[0] with
        | "todo" -> Ok (Todo splitLine.[1])
        | "list" -> Ok List
        | "echo" -> Ok (Echo splitLine.[1])
        | "bye" -> Ok Bye
        | _ -> Error (ParseError "Parse Error")
