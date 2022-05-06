namespace Fluke

module DomainTypes =
    open Common

    type Task =
        | Todo of description: string
        | Event of description: string
        | Deadline of description: string

    type Command = 
        | Add of Task
        | List
        | Bye
        | Empty

    type State = {
        tasks: Task list
    }

    type StateResult = Result<State, ErrorMessage>