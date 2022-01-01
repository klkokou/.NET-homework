﻿using Homework6;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Homework6Tests
{
    public class HostBuilder : WebApplicationFactory<App.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<App.Startup>()
                    .UseTestServer());
    }
}