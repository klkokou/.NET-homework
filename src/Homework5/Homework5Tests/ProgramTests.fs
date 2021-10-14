module Homework5Tests.ProgramTests

open Homework5
open Xunit
open Program
open Calculator

[<Fact>]
let Main_WrongInputData_WillReturnOne () =
    let args = [|"1984";"+";"qu"|]
    let check = main args
    let result = check = 1
    Assert.True(result)

[<Fact>]
let Main_CorrectInputData_WillReturnZero () =
    let args = [|"1984";"+";"34"|]
    let check = main args
    let result = check = 0
    Assert.True(result)
    
[<Fact>]
let Error_Division_By_Zero() =
    let args = [|"1984";"/";"0"|]
    let check = main args
    let result = check = 1
    Assert.True(result)