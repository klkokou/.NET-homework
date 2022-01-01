using Homework8;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Homework8Tests
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
        private readonly HttpClient client;
        public Tests(HostBuilder fixture)
        {
            client = fixture.CreateClient();
        }

        [Theory]
        [InlineData("1984", "plus", "1", "1985")]
        [InlineData("1985", "minus", "1", "1984")]
        [InlineData("2", "multiply", "992", "1984")]
        [InlineData("3968", "divide", "2", "1984")]
        [InlineData("123.3", "plus", "321.1", "444.4")]
        [InlineData("123.4", "minus", "321.11", "-197.71")]
        [InlineData("2.5", "multiply", "0", "0.0")]
        [InlineData("1.5", "divide", "1.5", "1")]
        public async Task CorrectInput_WillReturnCorrectResult(string v1, string operation, string v2, string excepted)
        {
            await RunTests(v1, operation, v2, excepted);
        }

        [Theory]
        
        [InlineData("4m", "minus", "yeet", "Invalid input values")]
        [InlineData("yeet", "minus", "4", "Invalid input values")]
        [InlineData("10", "yeet", "5", "Invalid input operation")]
        [InlineData("2.3", "min", "3.1", "Invalid input operation")]
        [InlineData("3.45", "mul", "5", "Invalid input operation")]
        public async Task InvalidInput_WillReturnError(string v1, string operation, string v2, string excepted)
        {
            await RunTests(v1, operation, v2, excepted);
        }
        [Theory]
        [InlineData("1984", "divide", "0", "Division by zero")]
        [InlineData("1984.4", "divide", "0", "Division by zero")]
        public async Task DivisionByZero_WillReturnDivisionByZeroError(string v1,
            string operation,
            string v2,
            string expected)
        {
            await RunTests(v1, operation, v2, expected);
        }
        private async Task RunTests(string v1, string operation, string v2, string excepted)
        {
            var response = await client.GetAsync($"calculator/calculate?value1={v1}&operation={operation}&value2={v2}");
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(excepted, result);
        }
    }
}