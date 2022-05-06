namespace Fluke

module Task =
    open DomainTypes

    let taskDescription task =
        match task with
        | Todo desc -> "[T] " + desc
        | Event desc -> "[E] " + desc
        | Deadline desc -> "[D] " + desc

    let todo desc = Todo desc

    let event desc = Event desc

    let deadline desc = Deadline desc

