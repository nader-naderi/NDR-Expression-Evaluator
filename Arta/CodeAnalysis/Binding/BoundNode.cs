namespace Arta.CodeAnalysis.Binding
{
    // Have Multiple bound nodes.
    internal abstract class BoundNode
    {
        public abstract BoundNodeKind Kind { get; }
    }
}