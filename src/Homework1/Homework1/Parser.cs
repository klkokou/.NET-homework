using System;

namespace Homework1
{
    public static class Parser
    {
        private const int WrongArgsNumber = 1;
        private const int WrongValueFormat = 2;
        private const int WrongOperation = 3;
        private const int DivisionByZero = 4;

        public static int ParseArgs(
            string[] args,
            out int val1,
            out Calculator.SupportedOperations operation,
            out int val2)
        {
            val1 = val2 = (int)(operation = 0);
            if (Parser.CheckArgsNumber(args)) return WrongArgsNumber;
            if (Parser.TryParseValue(args[0], out val1)
                || Parser.TryParseValue(args[2], out val2)) return WrongValueFormat;
            if (Parser.TryParseOperator(args[1], out operation)) return WrongOperation;
            if (val2 == 0) return DivisionByZero;
            return 0;
        }

        private static bool CheckArgsNumber(string[] args)
        {
            if (args.Length == 3) return false;
            Console.WriteLine($"Programm needs 3 args, but there is {args.Length}");
            return true;
        }

        private static bool TryParseValue(string arg, out int result)
        {
            if (int.TryParse(arg, out result))
                return false;
            Console.WriteLine($"{arg} is not int");
            return true;
        }

        private static bool TryParseOperator(string arg, out Calculator.SupportedOperations operation)
        {
            switch (arg)
            {
                case "+":
                    operation = Calculator.SupportedOperations.Plus;
                    break;
                case "-":
                    operation = Calculator.SupportedOperations.Minus;
                    break;
                case "*":
                    operation = Calculator.SupportedOperations.Multiply;
                    break;
                case "/":
                    operation = Calculator.SupportedOperations.Divide;
                    break;
                default:
                    operation = default;
                    return true;
            }

            return false;
        }
    }
}