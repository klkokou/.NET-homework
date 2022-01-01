module Homework6.Parser

open Homework6.SupportedOperations

let tryParseOperation operation =
    match operation with
    | "plus" -> Ok Plus
    | "minus" -> Ok Minus
    | "multiply" -> Ok Multiply
    | "divide" -> Ok Divide
    | _ ->   Error $"Invalid input operation"