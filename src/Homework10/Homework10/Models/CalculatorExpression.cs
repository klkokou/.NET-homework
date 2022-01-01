using System.ComponentModel.DataAnnotations;

namespace Homework10.Models
{
    public class CalculatorExpression
    {
        public int CalculatorExpressionId { get; set; }
        [Required] public string Expression { get; init; }
        [Required] public string Answer { get; init; }
    }
}