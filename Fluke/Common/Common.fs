namespace Fluke

module Common =

    type Message = Message of string

    let unwrapMessage (Message msg) = msg

    let createMessage msg = Message msg

    type Command = 
    | Echo of string
    | Bye