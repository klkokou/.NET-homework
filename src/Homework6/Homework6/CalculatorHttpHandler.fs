module Homework6.CalculatorHttpHandler

open Giraffe
open MaybeBuilder
open CheckInput
open Input

let calculatorHttpHandler:HttpHandler=
    fun next ctx ->
        let inputValues = ctx.TryBindQueryString<Input>()
        let result = result{
            let! checkedInput = checkInput inputValues
            let! operation = Parser.tryParseOperation checkedInput.Operation
            let! result = Calculator.calculate checkedInput.V1 operation checkedInput.V2
            return result
        }
        match result with
        | Ok res ->
             (setStatusCode 200 >=> json res) next ctx
        | Error res ->
            (setStatusCode 400 >=> json res) next ctx