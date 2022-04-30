namespace Fluke

module UseCases =
    open Common

    let mutable doExit = false;

    let todo arg =
        Task.todo arg
        |> TaskRepository.addTask
        |> Result.map createMessage

    let event arg = 
        Task.event arg
        |> TaskRepository.addTask
        |> Result.map createMessage

    let deadline arg = 
        Task.deadline arg
        |> TaskRepository.addTask
        |> Result.map createMessage

    let list() =
        TaskRepository.listTasks()
        |> Result.map createMessage

    let echo msg = Ok (createMessage msg)

    let bye() =
        doExit <- true
        Ok (createMessage "See you later!")

    let execute cmd =
        match cmd with
        | Todo arg -> todo arg
        | Event arg -> event arg
        | Deadline arg -> deadline arg
        | List -> list()
        | Echo msg -> echo msg
        | Bye -> bye()

    let handleUses input =
        Parser.parse input
        |> Result.bind execute
        |> UI.formattedPrint
       