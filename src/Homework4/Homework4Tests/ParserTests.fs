module Tests.ParserTests

open Homework4
open Xunit

[<Theory>]
[<InlineData("+", Calculator.SupportedOperations.Plus)>]
[<InlineData("-", Calculator.SupportedOperations.Minus)>]
[<InlineData("*", Calculator.SupportedOperations.Multiply)>]
[<InlineData("/", Calculator.SupportedOperations.Divide)>]
let ParseCalcArguments_Operation_WillParse (operation, operationExpected) =
    let args = [|"4";operation;"777"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Calculator.SupportedOperations.Plus
    let check = Parser.parseArgs args &val1 &operationResult &val2
    Assert.Equal(Parser.Parser.Correct, check)
    Assert.Equal(4, val1)
    Assert.Equal(operationExpected, operationResult)
    Assert.Equal(777, val2)

[<Fact>]
let ParseArgs_NotNumber_WillReturnWrongValueFormat () =
    let args = [|"4";"+";"9348hg"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Calculator.SupportedOperations.Plus
    let check = Parser.parseArgs args &val1 &operationResult &val2
    Assert.Equal(Parser.Parser.WrongValueFormat, check)

[<Fact>]
let ParseArgs_NotOperation_WillReturnWrongOperation () =
    let args = [|"4";"qu";"1984"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Calculator.SupportedOperations.Plus
    let check = Parser.parseArgs args &val1 &operationResult &val2
    Assert.Equal(Parser.Parser.WrongOperation, check)

[<Fact>]
let ParseCalcArguments_WrongLengthArgs_WillReturnWrongArgsNumber () =
    let args = [|"4";"+";"1984";"qu"|]
    let mutable val1 = 0
    let mutable val2 = 0
    let mutable operationResult = Calculator.SupportedOperations.Plus
    let check = Parser.parseArgs args &val1 &operationResult &val2
    Assert.Equal(Parser.Parser.WrongArgsNumber, check)
    
[<Fact>]
let ParseCalcArguements_DivisionByZero_WillReturnDivisionByZero () =
   let args = [|"2";"/";"0";|]
   let mutable val1 = 0
   let mutable val2 = 0
   let mutable operationResult = Calculator.SupportedOperations.Divide
   let check = Parser.parseArgs args &val1 &operationResult &val2
   Assert.Equal(Parser.Parser.DivisionByZero, check)
     