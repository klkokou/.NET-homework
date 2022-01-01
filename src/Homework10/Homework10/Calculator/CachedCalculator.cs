using Homework10.Interfaces;
using Homework10.Models;
using System.Linq;

namespace Homework10.Calculator
{
    public class CashedCalculator : CalculatorDecorator
    {
        private readonly CalculatorContext cachedExpression;

        public CashedCalculator(ICalculator calculator, CalculatorContext cachedExpression) : base(calculator)
        {
            this.cachedExpression = cachedExpression;
        }

        public override Answer<string, string> Calculate(string expression)
        {
            var cacheAnswer = cachedExpression.CalculatorExpressions.FirstOrDefault(exp => exp.Expression == expression)
                ?.Answer;
            if (cacheAnswer is not null) return new Answer<string, string>(correct:cacheAnswer);
            var answer = calculator.Calculate(expression);
            if (answer.AnswerType == AnswerType.Wrong) return answer;
            var newExpression = new CalculatorExpression { Expression = expression, Answer = answer.Correct };
            cachedExpression.Add(newExpression);
            cachedExpression.SaveChanges();
            return answer;
        }
    }
}