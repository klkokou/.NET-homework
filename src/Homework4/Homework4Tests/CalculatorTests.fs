module Tests.CalculatorTests

open Homework4
open Xunit

[<Theory>]
[<InlineData(12,78,90)>]
[<InlineData(1,0,1)>]
[<InlineData(4,-100,-96)>]

let Calculate_WithPlusOperation_SumReturned (val1, val2, expected) =
    let result = Calculator.calculate val1 Calculator.SupportedOperations.Plus val2
    Assert.Equal(result, expected)
    
[<Theory>]
[<InlineData(134,4,130)>]
[<InlineData(4,0,4)>]
[<InlineData(4,-100,104)>]

let Calculate_WithMinusOperation_DifferenceReturned (val1, val2, expected) =
    let result = Calculator.calculate val1 Calculator.SupportedOperations.Minus val2
    Assert.Equal(result, expected)
    
[<Theory>]
[<InlineData(134,4,536)>]
[<InlineData(4,0,0)>]
[<InlineData(4,-100,-400)>]

let Calculate_WithMultiplyOperation_ProductReturned (val1, val2, expected) =
    let result = Calculator.calculate val1 Calculator.SupportedOperations.Multiply val2
    Assert.Equal(result, expected)
    
[<Theory>]
[<InlineData(134,4,33.5)>]
[<InlineData(0,4,0)>]
[<InlineData(4,-100,-0.04)>]

let Calculate_WithMultiplyOperation_QuotientReturned (val1, val2, expected) =
    let result = Calculator.calculate val1 Calculator.SupportedOperations.Divide val2
    Assert.Equal(result, expected)