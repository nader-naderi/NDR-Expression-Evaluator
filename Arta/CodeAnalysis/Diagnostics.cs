namespace Arta.CodeAnalysis
{
    public sealed class Diagnostics
    {
        public Diagnostics(TextSpan span, string message)
        {
            Span = span;
            Message = message;
        }

        public TextSpan Span { get; }
        public string Message { get; }

        public override string ToString() => Message;
    }
}