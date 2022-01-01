using Homework11.Interfaces;

namespace Homework11.Calculator
{
    public class CalculatorDecorator : ICalculator
    {
        protected readonly ICalculator calculator;

        protected CalculatorDecorator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public virtual string Calculate(string expression)
        {
            return calculator.Calculate(expression);
        }
    }
}