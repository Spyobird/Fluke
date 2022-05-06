namespace Fluke

module Adapters =
    open Application
    open DomainTypes

    let UiAdapter: Adapter = fun command state ->
        match command with
        | Add task -> UI.formattedPrint "Added new task"
        | List ->
            let msg =
                ("Listed " + string (List.length state.tasks) + " tasks:", state.tasks)
                ||> List.fold (fun acc t -> acc + "\n" + (Task.taskDescription t))
            UI.formattedPrint msg
        | Bye -> UI.formattedPrint "See you again"
        | _ -> ()
        State.lift state

    let PersistenceAdapter: Adapter = fun command state ->
        match command with
            | Add task -> TaskRepository.addTask task
            | _ -> Ok ()
        |> Result.map (fun () -> state)
            
