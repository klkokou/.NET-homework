module Homework5Tests.ParserTests

open Homework5
open Xunit
open Calculator
open Parser

[<Fact>]
let ParseCalcArguments_Operation_WillParse () =
    Assert.Equal(Ok(decimal 4, SupportedOperations.Plus, decimal 777), parseArgs [| "4"; "+"; "777" |])
    Assert.Equal(Ok(decimal 5634, SupportedOperations.Minus, decimal 777), parseArgs [| "5634"; "-"; "777" |])
    Assert.Equal(Ok(decimal 4, SupportedOperations.Divide, decimal 777), parseArgs [| "4"; "/"; "777" |])
    Assert.Equal(Ok(decimal 5634, SupportedOperations.Multiply, decimal 777), parseArgs [| "5634"; "*"; "777" |])

[<Fact>]
let ParseArgs_NotNumber_WillReturnWrongValueFormat () =
    Assert.Equal(Error "Wrong value format", parseArgs[|"4";"+";"9348hg"|])
    Assert.Equal(Error "Wrong value format", parseArgs[|"9348hg";"+";"4"|])

[<Fact>]
let ParseArgs_NotOperation_WillReturnWrongOperation () =
    Assert.Equal(Error "Wrong operation: qu", parseArgs [|"4";"qu";"1984"|])

[<Fact>]
let ParseCalcArguments_WrongLengthArgs_WillReturnWrongArgsNumber () =
    Assert.Equal(Error "Program needs 3 args, but there is 4", parseArgs [|"4";"+";"1984";"qu"|])
    
[<Fact>]
let ParseCalcArguments_ZeroDivision_WillDivisionByZero () =
    Assert.Equal(Error "Division By Zero", parseArgs [|"4";"/";"0"|])