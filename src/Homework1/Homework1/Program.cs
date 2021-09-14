using System;
using System.Linq;

namespace Homework1
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            String[] SupportedOperations =
            {
                "+",
                "-",
                "*",
                "/"
            };
            var isVal1Int = int.TryParse(args[0], out var val1);
            var operation = args[1];
            var isVal2Int = int.TryParse(args[0], out var val2);
            var result = 0;

            if (!SupportedOperations.Contains(operation))
            {
                Console.WriteLine($"{args[0]} {args[1]} {args[2]} is not valid calculation syntax." +
                                  $"Supported operations are" +
                                  $"{SupportedOperations.Aggregate((c, n) => $"{c}{n}")}");
                return 1;
            }

            switch (operation)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "/":
                    result = val1 / val2;
                    break;
            }

            return 0;
        }
    }
}