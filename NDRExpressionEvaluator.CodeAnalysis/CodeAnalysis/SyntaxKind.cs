namespace NDRExpressionEvaluator.CodeAnalysis
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

        // Expressions
        NumberExpression,
        BinaryExpression,
        ParanthesizedExpression
    }
}