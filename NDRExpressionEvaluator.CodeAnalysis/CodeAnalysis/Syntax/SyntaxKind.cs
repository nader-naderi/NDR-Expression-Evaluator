namespace NDRExpressionEvaluator.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        NumberToken,
        WhitespaceToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParanthesisToken,
        CloseParanthesisToken,

        // Keywords
        FalseKeyword,
        TrueKeyword,
        IdentifierToken,

        // Expressions
        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParanthesizedExpression,
    }
}