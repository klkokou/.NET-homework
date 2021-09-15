using System;

namespace Homework1
{
    public static class Program
    {
        private const int NotEnoughtArgs = 1;
        private const int WrongArgFormat = 2;
        private const int WrongOperation = 3;
        private const int AttemptToDevideByZero = 4;

        public static int Main(string[] args)
        {
            if (Parser.CheckArgsLenghtOrQuit(args))
                return NotEnoughtArgs;

            if (Parser.TryParseArgsOrQuit(args[0], out var val1) || Parser.TryParseArgsOrQuit(args[2], out var val2))
                return WrongArgFormat;

            if (Parser.TryParseOperatorOrQuit(args[1], out var operation))
                return WrongOperation;

            if (Calculator.Calculate(val1, operation, val2, out var result))
                return AttemptToDevideByZero;

            Console.WriteLine($"Result : {result}");

            return 0;
        }
    }
}