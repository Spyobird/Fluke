namespace Fluke

module Task =
    open TaskTypes

    let createDescription desc = 
        Description desc

    let taskDescription task =
        match task with
        | Todo (Description desc) ->  desc

    let todo desc =
        Todo (createDescription desc)

