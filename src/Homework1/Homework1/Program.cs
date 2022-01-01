using System;

namespace Homework1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parseCode = Parser.ParseArgs(args, out var val1, out var operation, out var val2);
            if (parseCode != 0) return parseCode;

            var result = Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result is {result}");
            return 0;
        }
    }
}