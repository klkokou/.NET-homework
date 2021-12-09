using System.Linq;
using Homework11.Interfaces;
using Homework11.Models;

namespace Homework11.Calculator
{
    public class CashedCalculator : CalculatorDecorator
    {
        private readonly CalculatorContext cachedExpression;

        public CashedCalculator(ICalculator calculator, CalculatorContext cachedExpression) : base(calculator)
        {
            this.cachedExpression = cachedExpression;
        }

        public override string Calculate(string expression)
        {
            var cacheAnswer = cachedExpression.CalculatorExpressions.FirstOrDefault(exp => exp.Expression == expression)
                ?.Answer;
            if (cacheAnswer is not null) return cacheAnswer;
            var answer = calculator.Calculate(expression);
            var newExpression = new CalculatorExpression { Expression = expression, Answer = answer };
            cachedExpression.Add(newExpression);
            cachedExpression.SaveChanges();
            return answer;
        }
    }
}