module Homework5.Calculator

open Homework5
open MaybeBuilder

type SupportedOperations =
    | Plus = 1
    | Minus = 2
    | Divide = 3
    | Multiply = 4
    
let calculate (val1 : decimal, operation, val2) =
    (*let division val1 val2 =
        if val1 = decimal 0 then
            Error "Division by zero"
        else
            Ok(val2 / val1)*)
            
    result {
        match operation with
        | SupportedOperations.Plus -> return val1 + val2
        | SupportedOperations.Minus -> return val1 - val2
        | SupportedOperations.Multiply -> return val1 * val2
        | SupportedOperations.Divide -> return val1/ val2
    }