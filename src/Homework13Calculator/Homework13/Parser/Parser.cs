using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Homework13.Calculator;

namespace Homework13.Parser
{
    public class Parser
    {
        public static Expression ConvertToExpression(IEnumerable<Variables.Variable> variables)
        {
            var outStack = new Stack<Expression>();
            var opStack = new Stack<Variables.Variable>();
            foreach (var currentVar in variables)
            {
                switch (currentVar.Type)
                {
                    case Variables.VariableType.Number:
                        outStack.Push(Expression.Constant((1) * double.Parse(currentVar.Value), typeof(double)));
                        break;
                    case Variables.VariableType.Operation:
                        ProcessInputOperations(currentVar, outStack, opStack);
                        break;
                    case Variables.VariableType.Parenthesis when currentVar.Value == "(":
                        opStack.Push(currentVar);
                        break;
                    case Variables.VariableType.Parenthesis:
                        ProcesOpenBracket(outStack, opStack);
                        break;
                }
            }

            ProcessLastOperation(outStack, opStack);
            return outStack.Pop();
        }

        private static void ProcessInputOperations(Variables.Variable operation, Stack<Expression> outputStack,
            Stack<Variables.Variable> opStack)
        {
            while (opStack.Count > 0 && Priority.priority[opStack.Peek().Value] >= Priority.priority[operation.Value])
                MakeExpression(outputStack, opStack.Pop());
            opStack.Push(operation);
        }

        private static void ProcesOpenBracket(Stack<Expression> outputStack, Stack<Variables.Variable> opStack)
        {
            var operation = opStack.Pop();
            while (opStack.Count > 0 && operation.Value != "(")
            {
                MakeExpression(outputStack, operation);
                operation = opStack.Pop();
            }
        }

        private static void ProcessLastOperation(Stack<Expression> outputStack, Stack<Variables.Variable> opStack)
        {
            while (opStack.Count > 0) MakeExpression(outputStack, opStack.Pop());
        }

        private static void MakeExpression(Stack<Expression> outputStack, Variables.Variable operation)
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

        public static Answer<List<Variables.Variable>, string> ParseForVariables(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return new Answer<List<Variables.Variable>, string>(new List<Variables.Variable>());
            var variables = new List<Variables.Variable>();
            var value = "";
            var errorInputMessage = ErrorMessages.errorMessages[4];
            foreach (var val in expression.Replace(" ", ""))
            {
                if (Parenthesis.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, Variables.VariableType.Parenthesis))
                        return new Answer<List<Variables.Variable>, string>(errorInputMessage);
                }
                else if (SupportedOperations.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, Variables.VariableType.Operation))
                        return new Answer<List<Variables.Variable>, string>(errorInputMessage);
                }
                else if (char.IsDigit(val) || val == ',') value += val;
                else return new Answer<List<Variables.Variable>, string>(errorInputMessage);
            }

            if (string.IsNullOrEmpty(value)) return new Answer<List<Variables.Variable>, string>(variables);
            if (!double.TryParse(value, out var result)) return new Answer<List<Variables.Variable>, string>(errorInputMessage);
            variables.Add(new Variables.Variable(Variables.VariableType.Number, value));
            return new Answer<List<Variables.Variable>, string>(variables);
        }

        private static bool IsSupportedVariable(ref string num, ICollection<Variables.Variable> variables, char variableValue,
            Variables.VariableType variableType)
        {
            if (!string.IsNullOrEmpty(num))
            {
                if (!double.TryParse(num, out var result)) return false;
                variables.Add(new Variables.Variable(Variables.VariableType.Number, num));
                num = "";
            }

            variables.Add(new Variables.Variable(variableType, variableValue.ToString()));
            return true;
        }
    }

    public static class ParserForCorrectness
    {
        public static bool IsExpressionCorrect(IEnumerable<Variables.Variable> expressionInVariables, out string errorMessage)
        {
            errorMessage = "";
            var inVariablesList = expressionInVariables.ToList();
            if (!inVariablesList.Any())
            {
                errorMessage = ErrorMessages.errorMessages[1];
                return false;
            }

            Variables.Variable? nextVar = null;
            foreach (var currentVar in inVariablesList)
            {
                switch (currentVar.Type)
                {
                    case Variables.VariableType.Operation:
                    {
                        if (nextVar?.Type is Variables.VariableType.Operation) errorMessage = ErrorMessages.errorMessages[2];
                        break;
                    }
                    case Variables.VariableType.Parenthesis:
                    {
                        if (nextVar?.Type is Variables.VariableType.Operation && currentVar.Value == ")")
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