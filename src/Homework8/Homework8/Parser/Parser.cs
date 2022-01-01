using System;
using System.Globalization;
using Homework8.Interfaces;

namespace Homework8.Parser
{
    public class Parser : IParser
    {
        public void ParseArgs(string val1, string operation, string val2, ref IInput input)
        {
            if (TryParseValue(val1, out var val1Parsed)) input.ErrorMessage = "Invalid input values";
            if (TryParseValue(val2, out var val2Parsed)) input.ErrorMessage = "Invalid input values";
            if (TryParseOperation(operation, out var operationParsed)) input.ErrorMessage = "Invalid input operation";
            if (input.ErrorMessage is not null) return;
            if (CheckDivisionByZero(operationParsed, val2Parsed)) input.ErrorMessage = "Division by zero";
            input.Value1 = val1Parsed;
            input.Operation = operationParsed;
            input.Value2 = val2Parsed;
        }

        private  static bool TryParseOperation(string operation, out SupportedOperations operationParsed) 
            => !Enum.TryParse(operation, true, out operationParsed);

        private static bool TryParseValue(string val, out decimal valParsed) 
            => !decimal.TryParse(val, NumberStyles.Number, CultureInfo.InvariantCulture, out valParsed);

        private static bool CheckDivisionByZero(SupportedOperations operation, decimal denominator) 
            => operation == SupportedOperations.Divide && denominator == 0;
    }
}