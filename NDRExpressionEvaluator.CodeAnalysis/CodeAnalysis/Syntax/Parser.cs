namespace NDRExpressionEvaluator.CodeAnalysis.Syntax
{
    internal sealed class Parser
    {
        private readonly SyntaxToken[] _tokens;

        private List<string> _diagnostics = new List<string>();

        private int _position;


        public Parser(string text)
        {
            List<SyntaxToken> tokens = new List<SyntaxToken>();

            Lexer lexer = new Lexer(text);

            SyntaxToken token;
            do
            {
                token = lexer.Lex();

                if (token.Kind != SyntaxKind.WhitespaceToken && token.Kind != SyntaxKind.BadToken)
                    tokens.Add(token);

            } while (token.Kind != SyntaxKind.EndOfFileToken);

            _tokens = tokens.ToArray();
            _diagnostics.AddRange(lexer.Diagnostics);
        }

        private SyntaxToken Peek(int offset)
        {
            var index = _position + offset;
            if (index >= _tokens.Length)
                return _tokens[_tokens.Length - 1];

            return _tokens[index];
        }

        public IEnumerable<string> Diagnostics => _diagnostics;

        private SyntaxToken Current => Peek(0);

        private SyntaxToken NextToken()
        {
            var current = Current;
            _position++;
            return current;
        }

        private SyntaxToken MatchToken(SyntaxKind kind)
        {
            if (Current.Kind == kind) return NextToken();


            _diagnostics.Add($"ERROR : Unexpected Token <{Current.Kind}>, expected <{kind}>");

            return new SyntaxToken(kind, Current.Position, null, null);
        }

        public SyntaxTree Parse()
        {
            var expression = ParseExpression();
            var endOfFileToken = MatchToken(SyntaxKind.EndOfFileToken);
            return new SyntaxTree(_diagnostics, expression, endOfFileToken);
        }

        private ExpressionSyntax ParseExpression(int parentPrecedence = 0)
        {
            ExpressionSyntax left;
            var unaryOperatorPrecedence = Current.Kind.GetBinaryOperatorPrecedence();
            if (unaryOperatorPrecedence != 0 && unaryOperatorPrecedence >= parentPrecedence)
            {
                var OperatorToken = NextToken();
                var operand = ParseExpression(unaryOperatorPrecedence);
                left = new UnaryExpressionSyntax(OperatorToken, operand);

            }
            else
            {
                left = ParsePrimaryExpression();

            }

            while (true)
            {
                var precedence = Current.Kind.GetBinaryOperatorPrecedence();
                if (precedence == 0 || precedence <= parentPrecedence) // parse it later.
                    break;

                var operatorToken = NextToken();
                var right = ParseExpression(precedence);
                left = new BinaryExpressionSyntax(left, operatorToken, right);
            }

            return left;
        }




        private ExpressionSyntax ParsePrimaryExpression()
        {
            switch (Current.Kind)
            {
                case SyntaxKind.OpenParanthesisToken:
                    {
                        var left = NextToken();
                        var expression = ParseExpression();
                        var right = MatchToken(SyntaxKind.CloseParanthesisToken);
                        return new ParanthesizedExpressionSyntax(left, expression, right);
                    }

                case SyntaxKind.FalseKeyword:
                case SyntaxKind.TrueKeyword:
                    {
                        var KeywordToken = NextToken();
                        var value = KeywordToken.Kind == SyntaxKind.TrueKeyword;
                        return new LiteralExpressionSyntax(KeywordToken, value);
                    }
                default:
                    {
                        var numberToken = MatchToken(SyntaxKind.NumberToken);
                        return new LiteralExpressionSyntax(numberToken);
                    }
            }


        }
    }
}