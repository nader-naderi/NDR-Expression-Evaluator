using System.Collections;
using Arta.CodeAnalysis.Syntax;

namespace Arta.CodeAnalysis
{
    internal sealed class DiagnosticBag : IEnumerable<Diagnostics>
    {
        private readonly List<Diagnostics> _diagnostics = new List<Diagnostics>();

        public IEnumerator<Diagnostics> GetEnumerator() => _diagnostics.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void AddRange(DiagnosticBag diagnostics)
        {
            _diagnostics.AddRange(diagnostics._diagnostics);
        }

        public void Report(TextSpan span, string message)
        {
            var diagnostic = new Diagnostics(span, message);
            _diagnostics.Add(diagnostic);
        }

        public void ReportInvalidNumber(TextSpan textSpan, string text, Type type)
        {
            var message = $"The number {text} is not valid {type}.";
            Report(textSpan, message);
        }

        public void ReportBadCharacter(int position, char current)
        {
            var message = $"Bad Charcater input : '{current}'.";
            var span = new TextSpan(position, 1);
            Report(span, message);
        }

        public void ReportUnexpectedToken(TextSpan span, SyntaxKind actualKind, SyntaxKind expectedKind)
        {
            var message = $"Unexpected Token <{actualKind}>, expected <{expectedKind}>.";
            Report(span, message);
        }

        public void ReportUndefinedUnaryOperator(TextSpan span, string? operatorText, Type operandType)
        {
            var message = $"Unary operator '{operatorText}' is not defind for type {operandType}.";
            Report(span, message);
        }

        public void ReportUndefinedBinaryOperator(TextSpan span, string? operatorText, Type leftType, Type rightType)
        {
            var message = $"Binary operator '{operatorText}' is not defind for type {leftType} and {rightType}.";
            Report(span, message);
        }
    }
}