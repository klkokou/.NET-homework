using Homework8.Interfaces;

namespace Homework8.Parser
{
    public class Input : IInput
    {
        public decimal Value1 { get; set; }
        public SupportedOperations Operation { get; set; }
        public decimal Value2 { get; set; }
        public string ErrorMessage { get; set; }
    }
}