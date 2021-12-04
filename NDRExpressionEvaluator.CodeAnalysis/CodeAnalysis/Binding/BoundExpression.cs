namespace NDRExpressionEvaluator.CodeAnalysis.Binder
{
    internal abstract class BoundExpression : BoundNode
    {
        public abstract Type Type { get; }
    }
}