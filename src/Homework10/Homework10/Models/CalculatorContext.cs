using Microsoft.EntityFrameworkCore;

namespace Homework10.Models
{
    public class CalculatorContext : DbContext
    {
        public DbSet<CalculatorExpression> CalculatorExpressions { get; set; }

        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}