module Homework5.MaybeBuilder

type MaybeBuilder() =
    member this.Zero() = Error "Division By Zero"

    member this.Bind(x, f) =
        match x with
        | Ok ok -> f ok
        | Error error -> Error error

    member this.Return(ok) = Ok ok

let result = MaybeBuilder()