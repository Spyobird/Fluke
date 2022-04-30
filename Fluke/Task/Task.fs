namespace Fluke

module Task =
    open TaskTypes

    let createDescription desc = Description desc

    let taskDescription task =
        match task with
        | Todo (Description desc) -> "[T] " + desc
        | Event (Description desc) -> "[E] " + desc
        | Deadline (Description desc) -> "[D] " + desc

    let todo desc = Todo (createDescription desc)

    let event desc = Event (createDescription desc)

    let deadline desc = Deadline (createDescription desc)

