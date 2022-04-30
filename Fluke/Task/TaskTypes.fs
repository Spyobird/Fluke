namespace Fluke

module TaskTypes =
    open System

    type Description = Description of string

    type Task =
        | Todo of Description
        | Event of Description
        | Deadline of Description