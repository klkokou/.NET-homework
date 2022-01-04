using System.Globalization;
using System.Linq.Expressions;
using Homework13.Interfaces;
using Homework13.Parser;

namespace Homework13.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly CalculatorVisitor visitor = new();

        public Answer<string, string> Calculate(string expression)
        {
            var variables = ParserForMathExpression.ParseForVariables(expression);
            if (variables.AnswerType == AnswerType.Wrong) return new Answer<string, string>(wrong: variables.Wrong);
            if (!ParserForCorrectness.IsExpressionCorrect(variables.Correct, out var errorMessage))
                return new Answer<string, string>(wrong: errorMessage);
            var resultExpression = visitor.Visit(Parser.Parser.ConvertToExpression(variables.Correct));
            var result = ((ConstantExpression)resultExpression)?.Value as double? ?? 0;
            return new Answer<string, string>(correct: result.ToString(CultureInfo.InvariantCulture));
        }
    }
}