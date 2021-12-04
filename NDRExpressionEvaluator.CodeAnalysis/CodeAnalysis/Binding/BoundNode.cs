namespace NDRExpressionEvaluator.CodeAnalysis.Binder
{
    // Have Multiple bound nodes.
    internal abstract class BoundNode
    {
        public abstract BoundNodeKind Kind { get; }
    }
}