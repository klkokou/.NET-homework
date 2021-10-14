module Homework5.Program

open Homework5
open Parser
open Calculator
open MaybeBuilder

[<EntryPoint>]
let main args =
    let result = result{
        let! args = parseArgs args
        let! result = calculate args
        return result
    }

    match result with
    | Ok resultValue ->
        printf $"Result is {resultValue}"
        0
    | Error errorValue ->
        printf $"{errorValue}"
        1
