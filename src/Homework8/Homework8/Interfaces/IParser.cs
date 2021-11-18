namespace Homework8.Interfaces
{
    public interface IParser
    {
        void ParseArgs(string val1, string operation, string val2, ref IInput input);
    }
}