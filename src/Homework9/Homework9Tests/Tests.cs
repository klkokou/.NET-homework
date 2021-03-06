using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Homework9;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Homework9Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(a => a
                    .UseStartup<Startup>()
                    .UseTestServer());
    }

    public class Tests : IClassFixture<HostBuilder>
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly HttpClient client;

        public Tests(HostBuilder fixture, ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("1981 %2B 3", "1984")]
        [InlineData("3 - 4 / 2", "1")]
        [InlineData("8 * (2 %2B 2) - 3 * 4", "20")]
        public async Task Calculator_Correct(string expression, string result)
        {
            await RunTest(expression, result, "Answer: ");
        }

        [Theory]
        [InlineData("", "Empty input")]
        [InlineData("10 + yeet", "Invalid input")]
        [InlineData("yeet", "Invalid input")]
        [InlineData("2 - 2,23,1 - 23", "Invalid input")]
        [InlineData("(20 - 1,,9,84) * 2", "Invalid input")]
        [InlineData("4 %2B 1,9,8,4", "Invalid input")]
        [InlineData("1984 - / 2", "There are two operations in a row")]
        [InlineData("10 - 2 * (10 - 1 /)", "Check brackets")]
        public async Task Calculator_Wrong(string expression, string result)
        {
            await RunTest(expression, result, "Error: ");
        }

        private async Task RunTest(string expression, string result, string successOrError)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent);
            var output = await response.Content.ReadAsStringAsync();

            Assert.Equal(successOrError + result, FindResult(output));
        }

        [Theory]
        [InlineData("45 %2B 45 / 45 * 45 * 45")]
        private async Task Calculator_TimeTest(string expression)
        {
            var watch = new Stopwatch();
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            watch.Start();
            await client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent);
            watch.Stop();
            var result = watch.ElapsedMilliseconds;
            _testOutputHelper.WriteLine(result.ToString());
            Assert.True(result - 1000 < 100);
        }

        private static string FindResult(string html)
        {
            return html.Split("<span id=\"response\" >")[1].Split("</span>")[0];
        }
    }
}