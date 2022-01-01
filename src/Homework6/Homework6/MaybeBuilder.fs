module Homework6.MaybeBuilder

type MaybeBuilder() =
    member this.Bind(ok, f) =
        match ok with
        | Ok ok -> f ok
        | Error error -> Error error

    member this.Return(ok) = Ok ok

let result = MaybeBuilder()