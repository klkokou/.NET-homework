using System.Collections.Generic;
using Homework13.Interfaces;

namespace Homework13.Calculator
{
    public class CashedCalculator : CalculatorDecorator
    {
        private readonly Dictionary<string, string> cachedExpression;

        public CashedCalculator(ICalculator calculator, Dictionary<string, string> cachedExpression) : base(calculator)
        {
            this.cachedExpression = cachedExpression;
        }

        public override Answer<string, string> Calculate(string expression)
        {
            if (expression is not null && cachedExpression.ContainsKey(expression))
                return new Answer<string, string>(correct: cachedExpression[expression]);
            var answer = calculator.Calculate(expression);
            if (answer.AnswerType == AnswerType.Wrong)
                return answer;
            cachedExpression[expression!] = answer.Correct;
            return answer;
        }
    }
}