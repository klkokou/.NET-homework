using Homework8.Interfaces;
using Homework8.Parser;

namespace Homework8.Calculator
{
    public class Calculator : ICalculator
    {
        public decimal Calculate(IInput input)
        {
            return input.Operation switch
            {
                SupportedOperations.Plus => input.Value1 + input.Value2,
                SupportedOperations.Minus => input.Value1 - input.Value2,
                SupportedOperations.Multiply => input.Value1 * input.Value2,
                SupportedOperations.Divide => input.Value1 / input.Value2,
            };
        }
    }
}