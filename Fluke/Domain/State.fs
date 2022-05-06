namespace Fluke

module State =
    open DomainTypes

    let initialState = {tasks = []}

    let lift: State -> StateResult = fun state -> Ok state

    let add task state =
        let newTasks = task :: state.tasks
        {state with tasks = newTasks}
