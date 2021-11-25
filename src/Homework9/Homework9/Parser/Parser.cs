#nullable enable
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Homework9.Calculator;

namespace Homework9.Parser
{
    public static class Parser
    {
        public static Expression ConvertToExpression(IEnumerable<Variable> variables)
        {
            var outStack = new Stack<Expression>();
            var opStack = new Stack<Variable>();
            foreach (var currentVar in variables)
            {
                switch (currentVar.Type)
                {
                    case VariableType.Number:
                        outStack.Push(Expression.Constant((1) * double.Parse(currentVar.Value), typeof(double)));
                        break;
                    case VariableType.Operation:
                        ProcessInputOperations(currentVar, outStack, opStack);
                        break;
                    case VariableType.Parenthesis when currentVar.Value == "(":
                        opStack.Push(currentVar);
                        break;
                    case VariableType.Parenthesis:
                        ProcesOpenBracket(outStack, opStack);
                        break;
                }
            }

            ProcessLastOperation(outStack, opStack);
            return outStack.Pop();
        }

        private static void ProcessInputOperations(Variable operation, Stack<Expression> outputStack,
            Stack<Variable> opStack)
        {
            while (opStack.Count > 0 && Priority.priority[opStack.Peek().Value] >= Priority.priority[operation.Value])
                MakeExpression(outputStack, opStack.Pop());
            opStack.Push(operation);
        }

        private static void ProcesOpenBracket(Stack<Expression> outputStack, Stack<Variable> opStack)
        {
            var operation = opStack.Pop();
            while (opStack.Count > 0 && operation.Value != "(")
            {
                MakeExpression(outputStack, operation);
                operation = opStack.Pop();
            }
        }

        private static void ProcessLastOperation(Stack<Expression> outputStack, Stack<Variable> opStack)
        {
            while (opStack.Count > 0) MakeExpression(outputStack, opStack.Pop());
        }

        private static void MakeExpression(Stack<Expression> outputStack, Variable operation)
        {
            var right = outputStack.Pop();
            outputStack.Push(Expression.MakeBinary(SupportedOperations.supportedOperations[operation.Value],
                outputStack.Pop(), right));
        }
    }

    public static class ParserForMathExpression
    {
        private static char[] Parenthesis { get; } = { '(', ')' };
        private static char[] SupportedOperations { get; } = { '+', '-', '/', '*' };

        public static Answer<List<Variable>, string> ParseForVariables(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return new Answer<List<Variable>, string>(new List<Variable>());
            var variables = new List<Variable>();
            var value = "";
            var errorInputMessage = ErrorMessages.errorMessages[4];
            foreach (var val in expression.Replace(" ", ""))
            {
                if (Parenthesis.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, VariableType.Parenthesis))
                        return new Answer<List<Variable>, string>(errorInputMessage);
                }
                else if (SupportedOperations.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, VariableType.Operation))
                        return new Answer<List<Variable>, string>(errorInputMessage);
                }
                else if (char.IsDigit(val) || val == ',') value += val;
                else return new Answer<List<Variable>, string>(errorInputMessage);
            }

            if (string.IsNullOrEmpty(value)) return new Answer<List<Variable>, string>(variables);
            if (!double.TryParse(value, out var result)) return new Answer<List<Variable>, string>(errorInputMessage);
            variables.Add(new Variable(VariableType.Number, value));
            return new Answer<List<Variable>, string>(variables);
        }

        private static bool IsSupportedVariable(ref string num, ICollection<Variable> variables, char variableValue,
            VariableType variableType)
        {
            if (!string.IsNullOrEmpty(num))
            {
                if (!double.TryParse(num, out var result)) return false;
                variables.Add(new Variable(VariableType.Number, num));
                num = "";
            }

            variables.Add(new Variable(variableType, variableValue.ToString()));
            return true;
        }
    }

    public static class ParserForCorrectness
    {
        public static bool IsExpressionCorrect(IEnumerable<Variable> expressionInVariables, out string errorMessage)
        {
            errorMessage = "";
            var inVariablesList = expressionInVariables.ToList();
            if (!inVariablesList.Any())
            {
                errorMessage = ErrorMessages.errorMessages[1];
                return false;
            }

            Variable? nextVar = null;
            foreach (var currentVar in inVariablesList)
            {
                switch (currentVar.Type)
                {
                    case VariableType.Operation:
                    {
                        if (nextVar?.Type is VariableType.Operation) errorMessage = ErrorMessages.errorMessages[2];
                        break;
                    }
                    case VariableType.Parenthesis:
                    {
                        if (nextVar?.Type is VariableType.Operation && currentVar.Value == ")")
                            errorMessage = ErrorMessages.errorMessages[3];
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(errorMessage)) return false;
                nextVar = currentVar;
            }

            return true;
        }
    }
}