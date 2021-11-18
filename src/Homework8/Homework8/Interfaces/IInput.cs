using Homework8.Parser;

namespace Homework8.Interfaces
{
    public interface IInput
    {
        decimal Value1 { get; set; }
        SupportedOperations Operation { get; set; }
        decimal Value2 { get; set; }
        string ErrorMessage { get; set; }
    }
}