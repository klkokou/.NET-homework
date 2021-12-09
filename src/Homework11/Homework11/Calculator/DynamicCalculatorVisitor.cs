using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework11.Calculator
{
    internal class DynamicCalculatorVisitor
    {
        public static double Visit(Expression expression) => Visit((dynamic)expression);
        private Expression Visit(ConstantExpression node) => node;
        private Expression Visit(BinaryExpression node)
        {
            var left = Task.Run(() => Visit(node.Left));
            var right = Task.Run(() => Visit(node.Right));
            Thread.Sleep(1000);
            var t = Task.WhenAll(left, right);
            t.Wait();
            var leftNode = left.Result;
            var rightNode = right.Result;
            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double))
            };
        }

        
    }
}