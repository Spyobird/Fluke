namespace Fluke

module Parser =
    open Common

    let parse (input: string) =
        let tokens = (trimString input).Split([|' '|], 2) |> List.ofArray |> List.map trimString
        let header = tokens.[0]
        let body =
            if List.length tokens = 1 then
                None
            else
                Some tokens.[1]
        {header = header; body = body}
