namespace NDRExpressionEvaluator.CodeAnalysis
{
    public sealed class LiteralExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken LiteralToken;

        public override SyntaxKind Kind => SyntaxKind.NumberExpression;
        public LiteralExpressionSyntax(SyntaxToken literalToken)
        {
            this.LiteralToken = literalToken;
        }

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return LiteralToken;
        }
    }
}