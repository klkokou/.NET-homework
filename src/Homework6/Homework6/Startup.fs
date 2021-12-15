module Homework6.App

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Microsoft.Extensions.DependencyInjection
open Giraffe

let webApp =
    choose [
        GET >=>
            choose [
                route "/calculate" >=> CalculatorHttpHandler.calculatorHttpHandler
            ]
        ]

type Startup() =
    member _.ConfigureServices (services : IServiceCollection) =
        services.AddGiraffe() |> ignore

    member _.Configure (app : IApplicationBuilder)
                        (_ : IHostEnvironment)
                        (_ : ILoggerFactory) =
        app.UseGiraffe webApp

    static member CreateHostBuilder (args:string[]) =
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                fun webHostBuilder ->
                    webHostBuilder
                        .UseStartup<Startup>()
                        |> ignore)