using Xunit;
using ConsoleApp1;

namespace TestProject1
{
    public class ProgramTests
    {
        [Fact]
        public void Main_WrongInput_WillReturnNotZero()
        {
            var args = new[] { "12", "+", "qu" };
            var result = Program.Main(args);
            Assert.True(result != 0);
        }
        
        [Fact]
        public void Main_CorrectInput_WillReturnZero()
        {
            var args = new[] { "12", "+", "34" };
            var result = Program.Main(args);
            Assert.True(result == 0);
        }
    }
}