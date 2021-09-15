using System;

namespace Homework1
{
    public static class Parser
    {
        public static bool TryParseOperatorOrQuit(string arg, out Calculator.SupportedOperations operation)
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

        public static bool TryParseArgsOrQuit(string arg, out int result)
        {
            if (int.TryParse(arg, out result))
                return false;
            Console.WriteLine($" Value is not int: {arg}");
            return true;
        }

        public static bool CheckArgsLenghtOrQuit(string[] args)
        {
            if (args.Length == 3) return false;
            Console.WriteLine($"Programm needs 3 args, but there is {args.Length}");
            return true;
        }
    }
}