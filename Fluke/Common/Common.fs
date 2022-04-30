namespace Fluke

module Common =

    type Message = Message of string

    let unwrapMessage (Message msg) = msg

    let createMessage msg = Message msg

    type Command = 
    | Todo of string
    | List
    | Echo of string
    | Bye