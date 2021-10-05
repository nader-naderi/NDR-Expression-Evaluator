namespace NDRExpressionEvaluator.CodeAnalysis.Syntax
{
    public class ParanthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParanthesizedExpressionSyntax(SyntaxToken openParanthesisToken, ExpressionSyntax expression, SyntaxToken closeParanthesisToken)
        {
            OpenParanthesisToken = openParanthesisToken;
            Expression = expression;
            CloseParanthesisToken = closeParanthesisToken;
        }

        public override SyntaxKind Kind => SyntaxKind.ParanthesizedExpression;

        public SyntaxToken OpenParanthesisToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParanthesisToken { get; }

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return OpenParanthesisToken;
            yield return Expression;
            yield return CloseParanthesisToken;
        }
    }
}