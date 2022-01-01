module Homework6.Program

open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main args =
    App.Startup
        .CreateHostBuilder(args)
        .Build()
        .Run()
    0