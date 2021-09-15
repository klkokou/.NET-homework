using Homework1;
using Xunit;

namespace Homework1Tests
{
    public class ParserTests
    {
        private const int Correct = 0;
        private const int WrongArgsNumber = 1;
        private const int WrongValueFormat = 2;
        private const int WrongOperation = 3;
        private const int DivisionByZero = 4;
            
        [Theory]
        [InlineData("+", Calculator.SupportedOperations.Plus)]
        [InlineData("-", Calculator.SupportedOperations.Minus)]
        [InlineData("*", Calculator.SupportedOperations.Multiply)]
        [InlineData("/", Calculator.SupportedOperations.Divide)]
        
        public void ParseArgs_Operation_WillParse(string operation, Calculator.SupportedOperations operationExpected)
        {
            var args = new[] { "34", operation, "1253" };
            var parseCode = Parser.ParseArgs(args, out var val1, out var operationResult, out var val2);
            Assert.Equal(Correct, parseCode);
            Assert.Equal(34, val1);
            Assert.Equal(operationExpected, operationResult);
            Assert.Equal(1253, val2);
        }
        
       
        [Fact]
        public void ParseArgs_NotNumber_WillReturnWrongArgFormatInt()
        {
            var args = new[] { "4", "+", "turn around" };
            var check = Parser.ParseArgs(args, out _, out _, out _);
            Assert.Equal(WrongValueFormat, check);
        }
        
        [Fact]
        public void ParseArgss_NotOperation_WillReturnWrongArgFormatOperation()
        {
            var args = new[] { "4", "turn around", "1337" };
            var check = Parser.ParseArgs(args, out _, out _, out _);
            Assert.Equal(WrongOperation, check);
        }
        [Fact]
        public void ParseCalcArguments_WrongLengthArgs_WillReturnWrongArgLength()
        {
            var args = new[] { "4", "+", "1337", "Timur" };
            var check = Parser.ParseArgs(args, out _, out _, out _);
            Assert.Equal(WrongArgsNumber, check);
        }

        [Fact]
        public void ParseCalcArguements_DivisionByZero_WillReturnDivisionByZero()
        {
            var args = new[] { "2", "/", "0" };
            var check = Parser.ParseArgs(args, out _, out _, out _);
            Assert.Equal(DivisionByZero, check);
        }
    }
}