using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Homework10;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;
using Xunit.Abstractions;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Homework10Tests
{
    public class HostBuilder : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(a => a.UseStartup<Startup>().UseTestServer());
    }

    public class Tests : IClassFixture<HostBuilder>
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly HttpClient client;

        public Tests(HostBuilder fixture, ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
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

        private static string FindResult(string html)
        {
            return html.Split("<span id=\"response\" >")[1].Split("</span>")[0];
        }

        [Theory]
        [InlineData("10*(5%2B5)")]
        [InlineData("1981 %2B 3")]
        [InlineData("3 - 4 / 2")]
        [InlineData("8 * (2 %2B 2) - 3 * 4")]
        [InlineData("((23-3)+(22%2B8))/(12%2B8)")]
        public async Task CachedCalculator_Faster(string expression)
        {
            var time1 = await GetTimeAsync(expression);
            var time2 = await GetTimeAsync(expression);
            testOutputHelper.WriteLine(time1.ToString());
            testOutputHelper.WriteLine(time2.ToString());
            Assert.True(time2 <= time1);
        }

        private async Task<long> GetTimeAsync(string expression)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = await client.GetAsync($"http://localhost:5000/Calculator/Calculate?expression={expression}");
            await response.Content.ReadAsStringAsync();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}