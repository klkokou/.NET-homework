module Homework6.Calculator

open Homework6
open SupportedOperations

let calculate (val1: decimal) operation (val2: decimal) =
    match operation with
    | Plus -> Ok(val1 + val2)
    | Minus -> Ok(val1 - val2)
    | Multiply -> Ok(val1 * val2)
    | Divide ->
        match val2 with
        | 0m -> Error "Division by zero"
        | _ -> Ok(val1 / val2)
