using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework10.Calculator
{
    internal class CalculatorVisitor: ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(() =>(double)(Visit(node.Left) as ConstantExpression).Value);
            var rightNodeTask = Task.Run(() => (double) (Visit(node.Right)as ConstantExpression).Value);
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;
            
            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double)),
            };
        }

        protected override Expression VisitConstant(ConstantExpression node) => node;
    }
}