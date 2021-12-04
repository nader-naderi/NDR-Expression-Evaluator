using System;
using System.Linq;

using NDRExpressionEvaluator.CodeAnalysis;
using NDRExpressionEvaluator.CodeAnalysis.Syntax;
using NDRExpressionEvaluator.CodeAnalysis.Binder;

namespace NDRExpressionEvaluator
{
    internal static class program
    {
        // Entry point.
        private static void Main()
        {
            bool showTree = false;
            while (true)
            {
                Console.Write("> ");

                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    return;

                var parser = new Parser(line);

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "showing parse tree" : "Not showing parse trees");
                    continue;
                }
                else if (line == "#cls")
                {
                    Console.Clear();
                    continue;
                }

                SyntaxTree syntaxTree = SyntaxTree.Parse(line);
                var binder = new Binder();
                var BoundExpression = binder.BindExpression(syntaxTree.Root);

                var diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();

                if (showTree)
                {
                    var color = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.DarkGray;

                    PrettyPrint(syntaxTree.Root);

                    Console.ForegroundColor = color;
                }

                if (!diagnostics.Any())
                {
                    var e = new Evaluator(BoundExpression);
                    var result = e.Evaluate();
                    Console.WriteLine("Result : " + result);
                }
                else
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;

                    foreach (var diagnostic in diagnostics)
                    {
                        Console.WriteLine(diagnostic);
                    }

                    Console.ForegroundColor = color;
                }
            }
        }

        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            // └──
            // ├──
            // │

            var marker = isLast ? "└──" : "├──";

            Console.Write(indent);

            Console.Write(marker);

            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            Console.WriteLine();

            indent += isLast ? "     " : "│    ";

            var lastChild = node.GetChildern().LastOrDefault();

            foreach (var child in node.GetChildern())
            {
                PrettyPrint(child, indent, child == lastChild);
            }
        }
    }


}