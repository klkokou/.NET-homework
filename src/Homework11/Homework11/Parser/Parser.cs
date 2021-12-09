using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Homework11.ExceptionHandler;

namespace Homework11.Parser
{
    public class Parser
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

        public static List<Variable> ParseForVariables(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return new List<Variable>();
            var variables = new List<Variable>();
            var value = "";
            var errorForInvalidInput = ErrorMessages.errorMessages[4];
            foreach (var val in expression.Replace(" ", ""))
            {
                if (Parenthesis.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, VariableType.Parenthesis))
                        throw new InvalidSymbolException(errorForInvalidInput);
                }
                else if (SupportedOperations.Contains(val))
                {
                    if (!IsSupportedVariable(ref value, variables, val, VariableType.Operation))
                        throw new InvalidSymbolException(errorForInvalidInput);
                }
                else if (char.IsDigit(val) || val == ',') value += val;

                throw new InvalidSymbolException(errorForInvalidInput);
            }

            if (!string.IsNullOrEmpty(value))
                if (!double.TryParse(value, out var result))
                    throw new ArgumentException(errorForInvalidInput);
            variables.Add(new Variable(VariableType.Number, value));
            return variables;
        }

        private static bool IsSupportedVariable(ref string num, ICollection<Variable> variables,
            char variableValue,
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
        public static void IsExpressionCorrect(IEnumerable<Variable> expressionInVariables)
        {
            var inVariables = expressionInVariables.ToList();
            if (!inVariables.Any())
            {
                throw new InvalidSyntaxException(ErrorMessages.errorMessages[1]);
            }

            Variable? nextVar = null;
            foreach (var currentVar in inVariables)
            {
                switch (currentVar.Type)
                {
                    case VariableType.Operation:
                    {
                        if (nextVar?.Type is VariableType.Operation)
                            throw new InvalidSyntaxException(ErrorMessages.errorMessages[2]);
                        break;
                    }
                    case VariableType.Parenthesis:
                    {
                        if (nextVar?.Type is VariableType.Operation && currentVar.Value == ")")
                            throw new InvalidSyntaxException(ErrorMessages.errorMessages[3]);
                        break;
                    }
                }

                nextVar = currentVar;
            }
        }
    }
}