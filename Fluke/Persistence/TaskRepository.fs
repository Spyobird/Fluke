namespace Fluke

module TaskRepository =
    open Common
    open DomainTypes

    let mutable taskList: Task list = []

    let addTask task =
        taskList <- task :: taskList
        Ok ()
