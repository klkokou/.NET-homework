module Homework4.Calculator

type SupportedOperations =
    | Plus = 1
    | Minus = 2
    | Divide = 3
    | Multiply = 4 
let calculate val1 operation val2 =
        let tempVal1 = val1 |> double
        let tempVal2 = val2 |> double
        match operation with
        | SupportedOperations.Plus -> tempVal1 + tempVal2
        | SupportedOperations.Minus -> tempVal1 - tempVal2
        | SupportedOperations.Divide ->tempVal1 / tempVal2
        | _ -> tempVal1  * tempVal2