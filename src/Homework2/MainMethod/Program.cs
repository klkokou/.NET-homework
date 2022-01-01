using System;

namespace ConsoleApp1
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            var parseCode = ClassLibrary1.Parser.ParseArgs(args, out var val1, out var operation, out var val2);
            if (parseCode != 0) return parseCode;

            var result = ClassLibrary1.Calculator.Calculate(val1, operation, val2);
            Console.WriteLine($"Result is {result}");
            return 0;
        }
    }
}