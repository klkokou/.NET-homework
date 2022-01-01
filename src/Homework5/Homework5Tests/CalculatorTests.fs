module Homework5Tests.CalculatorTests

open Homework5
open Xunit
open MaybeBuilder
open Calculator

let result = MaybeBuilder()

[<Theory>]
[<InlineData(12, SupportedOperations.Plus, 78, 90)>]
[<InlineData(1, SupportedOperations.Plus, 0, 1)>]
[<InlineData(4, SupportedOperations.Plus, -100, -96)>]

let CalculateInts_WithPlusOperation_SumReturned (val1, operation, val2, expected) =
    result {
        let! result = calculate (val1, operation, val2)
        Assert.Equal(result, expected)
    }

[<Theory>]
[<InlineData(134, SupportedOperations.Minus, 4, 130)>]
[<InlineData(4, SupportedOperations.Minus, 0, 4)>]
[<InlineData(4, SupportedOperations.Minus, -100, 104)>]

let CalculateInts_WithMinusOperation_DifferenceReturned (val1, operation, val2, expected) =
    result {
        let! result = calculate (val1, operation, val2)
        Assert.Equal(result, expected)
    }

[<Theory>]
[<InlineData(134, SupportedOperations.Multiply, 4, 536)>]
[<InlineData(4, SupportedOperations.Multiply, 0, 0)>]
[<InlineData(4, SupportedOperations.Multiply, -100, -400)>]

let CalculateInts_WithMultiplyOperation_ProductReturned (val1, operation, val2, expected) =
    result {
        let! result = calculate (val1, operation, val2)
        Assert.Equal(result, expected)
    }

[<Theory>]
[<InlineData(134, SupportedOperations.Divide, 4, 33.5)>]
[<InlineData(0, SupportedOperations.Divide, 4, 0)>]
[<InlineData(4, SupportedOperations.Divide, -100, -0.04)>]

let CalculateInts_WithDivideOperation_QuotientReturned (val1, operation, val2, expected) =
    result {
        let! result = calculate (val1, operation, val2)
        Assert.Equal(result, expected)
    }
    
[<Theory>]
[<InlineData(1.5, SupportedOperations.Plus, 2.1, 3.6)>]
[<InlineData(2.1, SupportedOperations.Minus, 1.5, 0.6)>]
[<InlineData(1.1, SupportedOperations.Multiply, 1.2, 1.32)>]
[<InlineData(1.5, SupportedOperations.Divide, 0.25, 6)>]
let Calculate_Floats (val1, op, val2, expectedResult) =
    result {
        let! actual = calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Theory>]
[<InlineData(0.123456789, SupportedOperations.Plus, 9.87654321, 9.999999999)>]
[<InlineData(9.87654321, SupportedOperations.Minus, 0.123456789, 9.753086421)>]
[<InlineData(1.12345, SupportedOperations.Multiply, 9.87654, 11.095798863)>]
[<InlineData(1.5, SupportedOperations.Divide, 0.25, 6)>]
let Calculate_Doubles (val1, op, val2, expectedResult) =
    result {
        let! actual = calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }

[<Theory>]
[<InlineData(0.123456789101112, SupportedOperations.Plus, 0.876543212345678, 1.000000001446790)>]
[<InlineData(0.876543212345678, SupportedOperations.Minus, 0.123456789101112, 0.753086423244566)>]
[<InlineData(0.1234567, SupportedOperations.Multiply, 0.98765432, 0.121932543087944)>]
[<InlineData(0.121932543087944, SupportedOperations.Divide, 0.98765432, 0.1234567)>]
let Calculate_Decimals (val1, op, val2, expectedResult) =
    result {
        let! actual = calculate (val1, op, val2)
        Assert.Equal(expectedResult, actual)
    }
