namespace Homework11.Parser
{
    public enum VariableType
    {
        Number,
        Operation,
        Parenthesis
    }

    public readonly struct Variable
    {
        public readonly VariableType Type;
        public readonly string Value;

        public Variable(VariableType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}