namespace NDRExpressionEvaluator.CodeAnalysis
{
    sealed class NumberExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken NumberToken;

        public override SyntaxKind Kind => SyntaxKind.NumberExpression;
        public NumberExpressionSyntax(SyntaxToken numberToken)
        {
            this.NumberToken = numberToken;
        }

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return NumberToken;
        }
    }
}