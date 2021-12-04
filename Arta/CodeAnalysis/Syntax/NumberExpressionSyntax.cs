namespace Arta.CodeAnalysis.Syntax
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public LiteralExpressionSyntax(SyntaxToken literalToken) : this(literalToken, literalToken.Value)
        {

        }

        public LiteralExpressionSyntax(SyntaxToken literalToken, object value)
        {
            this.LiteralToken = literalToken;
            Value = value;
        }
        public SyntaxToken LiteralToken;

        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public object Value { get; }


        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return LiteralToken;
        }
    }
}