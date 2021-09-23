using Xunit;
using ClassLibrary1;

namespace TestProject1
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(12, Calculator.SupportedOperations.Plus, 78)]
        [InlineData(1, Calculator.SupportedOperations.Plus, 0)]
        [InlineData(4, Calculator.SupportedOperations.Plus, -100)]
        public void Calculate_WithPlusOperation_SumReturned(int val1, Calculator.SupportedOperations operation, int val2)
        {
            var resultExpected = val1 + val2;
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(134, Calculator.SupportedOperations.Minus, 4)]
        [InlineData(4, Calculator.SupportedOperations.Minus, 0)]
        [InlineData(4, Calculator.SupportedOperations.Minus, -100)]
        
        public void Calculate_WithMinusOperation_DifferenceReturned(int val1, Calculator.SupportedOperations operation, int val2)
        {
            var resultExpected = val1 - val2;
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(resultExpected, result);
        }
        [Theory]
        [InlineData(1, Calculator.SupportedOperations.Multiply, 17)]
        [InlineData(9, Calculator.SupportedOperations.Multiply, 0)]
        [InlineData(7, Calculator.SupportedOperations.Multiply, -111)]
        public void Calculate_WithMultiplyOperation_ProductReturned(int val1, Calculator.SupportedOperations operation, int val2)
        {
            var resultExpected = val1 * val2;
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(resultExpected, result);
        }

        [Theory]
        [InlineData(10, Calculator.SupportedOperations.Divide, 4)]
        [InlineData(0, Calculator.SupportedOperations.Divide, 4)]
        [InlineData(307, Calculator.SupportedOperations.Divide, -10)]
        public void Calculate_WithDivideOperation_QuotientReturned(int val1, Calculator.SupportedOperations operation, int val2)
        {
            var resultExpected = (double)val1 / val2;
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(resultExpected, result);
        }
    }
}