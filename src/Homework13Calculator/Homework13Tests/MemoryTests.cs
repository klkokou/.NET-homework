using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using JetBrains.dotMemoryUnit;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Homework13Tests
{
    public class MemoryTests : IClassFixture<HostBuilder>
    {
        private readonly HttpClient client;
        private readonly ITestOutputHelper output;
        
        public MemoryTests(HostBuilder fixture, ITestOutputHelper output)
        {
            this.output = output;
            client = fixture.CreateClient();
            DotMemoryUnitTestOutput.SetOutputMethod(this.output.WriteLine);
        }
        
        [Fact]
        [DotMemoryUnit(FailIfRunWithoutSupport = false,CollectAllocations = true)]
        public void TestMemoryAsync()
        {
            var memoryPoint = dotMemory.Check();
            long size = 0;
            for (var i = 0; i < 10000000; i++)
            {
                var expression = $"{i}+{i}";
                size += Encoding.UTF8.GetBytes(expression).Length;
                SendRequest(expression);
            }
            
            dotMemory.Check(
                memory =>
                {
                    var allocatedMemory = memory.GetTrafficFrom(memoryPoint).CollectedMemory.SizeInBytes.ToString();
                    output.WriteLine(allocatedMemory);
                    output.WriteLine(size.ToString());
                    Assert.True(memory.GetTrafficFrom(memoryPoint).CollectedMemory.SizeInBytes >= size);
                });
        }
        private void SendRequest(string expression)
        {
            var stringContent = new StringContent($"expression={expression}", Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            client.PostAsync("https://localhost:5001/Calculator/Calculate", stringContent).GetAwaiter().GetResult();
        }
    }
}