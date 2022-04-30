namespace Fluke

module TaskRepository =
    open TaskTypes

    exception ListError of string

    let mutable taskList: Task list = []

    let addTask task =
        taskList <- task :: taskList
        Ok "Successfully added task to list"

    let listTasks() =
        if List.length taskList <> 0 then
            Ok (("Listed " + string (List.length taskList) + " tasks:", taskList)
            ||> List.fold (fun acc t -> acc + "\n" + (Task.taskDescription t)))
        else
            Error (ListError "List is empty")

