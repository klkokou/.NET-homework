using System.Globalization;
using Homework11.Interfaces;
using Homework11.Parser;

namespace Homework11.Calculator
{
    public class Calculator : ICalculator
    {
        public string Calculate(string expression)
        {
            var variables = ParserForMathExpression.ParseForVariables(expression);
            ParserForCorrectness.IsExpressionCorrect(variables);
            var convertedExpression = Parser.Parser.ConvertToExpression(variables);
            var result = DynamicCalculatorVisitor.Visit(convertedExpression);
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}