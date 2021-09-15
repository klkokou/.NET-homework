using System;

namespace Homework1
{
    public static class Parser
    {
        public static SupportedOperations ParseSupportedOperations(string arg) =>
            arg switch
            {
                "+" => SupportedOperations.Plus,
                "-" => SupportedOperations.Minus,
                "*" => SupportedOperations.Multiply,
                "/" => SupportedOperations.Plus,
                _ => default
            };

        private static bool CheckArgsLength(string[] args)
        {
            if (args.Length == 3)
                return true;
            Console.WriteLine($"Calculator requires 3 args but {args.Length} were given");
            return false;
        }
        
    }
}