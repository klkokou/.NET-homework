module Tests.ProgramTests

open Homework4
open Xunit

[<Fact>]
let Main_WrongInputData_WillReturnNotZero () =
    let args = [|"12";"+";"wvw23"|]
    let check = Program.main args
    Assert.True(check <> 0)

[<Fact>]
let Main_CorrectInputData_WillReturnZero () =
    let args = [|"12";"+";"34"|]
    let check = Program.main args
    let result = check = 0
    Assert.True(result)     