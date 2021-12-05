namespace Arta.CodeAnalysis.Syntax
{
    public sealed class NameExpressionSyntax : ExpressionSyntax
    {
        public NameExpressionSyntax(SyntaxToken identifireToken)
        {
            IdentifireToken = identifireToken;
        }

        public SyntaxToken IdentifireToken { get; }

        public override SyntaxKind Kind => SyntaxKind.NameExpression;

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return IdentifireToken;
        }
    }

    public sealed class AssignmentExpressionSyntax : ExpressionSyntax
    {
        public AssignmentExpressionSyntax(SyntaxToken identifireToken, SyntaxToken equalsToken, ExpressionSyntax expression)
        {
            IdentifireToken = identifireToken;
            EqualsToken = equalsToken;
            Expression = expression;
        }

        public SyntaxToken IdentifireToken { get; }
        public SyntaxToken EqualsToken { get; }
        public ExpressionSyntax Expression { get; }

        public override SyntaxKind Kind => SyntaxKind.NameExpression;

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return IdentifireToken;
            yield return EqualsToken;
            yield return Expression;

        }
    }

    public sealed class BinaryExpressionSyntax : ExpressionSyntax
    {
        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

        public ExpressionSyntax Left { get; }
        public SyntaxToken OperatorToken { get; }
        public ExpressionSyntax Right { get; }

        public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
        {
            Left = left;
            OperatorToken = operatorToken;
            Right = right;
        }

        public override IEnumerable<SyntaxNode> GetChildern()
        {
            yield return Left;
            yield return OperatorToken;
            yield return Right;
        }
    }
}