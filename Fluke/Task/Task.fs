namespace Fluke

module Task = 

    open TaskTypes

    let description desc = 
        Description desc

    let todo desc =
        Todo (description desc)

