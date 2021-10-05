using NDRExpressionEvaluator.CodeAnalysis.Binding;
using NDRExpressionEvaluator.CodeAnalysis.Syntax;
namespace NDRExpressionEvaluator.CodeAnalysis
{
    internal sealed class Evaluator
    {
        public Evaluator(BoundExpression root)
        {
            _root = root;
        }

        private readonly BoundExpression _root;

        public int Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private int EvaluateExpression(BoundExpression node)
        {
            // Binary expression.
            // Number expression.

            if (node is BoundLiteralExpression n)
                return (int)n.Value;

            if (node is BoundUnaryExpression u)
            {
                var operand = EvaluateExpression(u.Operand);

                switch (u.OperatorKind)
                {
                    case BoundUnaryOperatorKind.Identity:
                        return operand;
                    case BoundUnaryOperatorKind.Negation:
                        return -operand;
                    default:
                        throw new Exception($"Unexpected Uniary operator {u.OperatorKind}");
                }

            }

            if (node is BoundBinaryExpression b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);

                switch (b.OperatorKind)
                {
                    case BoundBinaryOperatorKind.Addition:
                        return left + right;
                    case BoundBinaryOperatorKind.Subtraction:
                        return left - right;
                    case BoundBinaryOperatorKind.Division:
                        return left / right;
                    case BoundBinaryOperatorKind.Mulitplication:
                        return left * right;
                    default:
                        throw new Exception($"Unexpected binary operator {b.OperatorKind}");
                }
            }


            throw new Exception($"Unexpected node  {node.Kind}");
        }
    }
}