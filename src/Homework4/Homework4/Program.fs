module Homework4.Program

[<EntryPoint>]
let main args =
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operation = Calculator.SupportedOperations.Plus

    let parseCode =
        Parser.parseArgs args &val1 &operation &val2

    if parseCode <> Parser.Parser.Correct then
        int parseCode
    else
        printf $"Result is {Calculator.calculate val1 operation val2}"
        0
