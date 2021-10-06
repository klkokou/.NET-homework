module Homework4.Parser

open System

type Parser =
    | Correct = 0
    | WrongArgsNumber = 1
    | WrongValueFormat = 2
    | WrongOperation = 3
    | DivisionByZero = 4

let checkArgsNumber (args: string []) =
    if args.Length = 3 then
        true
    else
        printf $"Program needs 3 args, but there is {args.Length}"
        false

let tryParseOperator (arg: string) (operation: outref<Calculator.SupportedOperations>) =
    operation <- match arg with
    | "+" -> Calculator.SupportedOperations.Plus
    | "-" -> Calculator.SupportedOperations.Minus
    | "/" -> Calculator.SupportedOperations.Divide
    | _ -> Calculator.SupportedOperations.Multiply
    operation <> Calculator.SupportedOperations.Multiply || arg = "*"

let parseArgs
    (args: string [])
    (val1: outref<int>)
    (operation: outref<Calculator.SupportedOperations>)
    (val2: outref<int>)
    =
    if not (checkArgsNumber args) then
        Parser.WrongArgsNumber
    elif not (Int32.TryParse(args.[0], &val1))
         || not (Int32.TryParse(args.[2], &val2)) then
        Parser.WrongValueFormat
    elif not (tryParseOperator args.[1] &operation) then
        Parser.WrongOperation
    elif (val2 = 0) && (args.[1]="/") then
        Parser.DivisionByZero
    else
        Parser.Correct
