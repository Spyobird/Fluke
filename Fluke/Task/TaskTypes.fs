namespace Fluke

module TaskTypes =
    type Description = Description of string

    type Task =
        | Todo of Description