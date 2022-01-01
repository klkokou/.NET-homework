module Homework5.Parser

open Homework5
open MaybeBuilder
open Calculator

let checkArgsNumber (args: string []) =
    match args.Length with
    | 3 -> Ok args
    | _ -> Error $"Program needs 3 args, but there is {args.Length}"

let tryParseOperation (args: string []) =
    result {
        let! operationResult =
            match args.[1] with
            | "+" -> Ok SupportedOperations.Plus
            | "-" -> Ok SupportedOperations.Minus
            | "/" -> Ok SupportedOperations.Divide
            | "*" -> Ok SupportedOperations.Multiply
            | _ -> Error $"Wrong operation: {args.[1]}"

        return args.[0], operationResult, args.[2]
    }

let checkForZeroDivision (val1: string, operation: SupportedOperations, val2: string) =
    result{
        if (operation = SupportedOperations.Divide)  && (val2 = "0")
        then Error |> ignore
        else
            return val1, operation, val2
    }

let parseValues (val1: string, operation: SupportedOperations, val2: string) =
    try
        Ok(val1 |> decimal, operation, val2 |> decimal)
    with
    | _ -> Error "Wrong value format"

let parseArgs (args: string []) =
    result {
        let! checkedArgsNumber = checkArgsNumber args
        let! checkedOperation = tryParseOperation checkedArgsNumber
        let! checkedForZeroDivision = checkForZeroDivision checkedOperation
        let! parsedValues = parseValues checkedForZeroDivision
        return parsedValues
    }
