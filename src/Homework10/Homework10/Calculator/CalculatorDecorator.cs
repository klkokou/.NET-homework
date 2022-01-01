using Homework10.Interfaces;

namespace Homework10.Calculator
{
    public class CalculatorDecorator : ICalculator
    {
        protected readonly ICalculator calculator;
        protected CalculatorDecorator(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        public virtual Answer<string, string> Calculate(string expression)
        {
            return calculator.Calculate(expression);
        }
    }
}