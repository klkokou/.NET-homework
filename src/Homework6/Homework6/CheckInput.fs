module Homework6.CheckInput

let checkInput input =
    match input with
    | Ok ok -> Ok ok
    | Error _ -> Error $"Invalid input values"