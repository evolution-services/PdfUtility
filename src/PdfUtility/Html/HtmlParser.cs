using PdfUtility.Html.Elements;
using System.Text.RegularExpressions;

namespace PdfUtility.Html
{
    public class HtmlParser
    {
        private readonly StyleInterpreter _styleInterpreter = new();
        private readonly HtmlTokenizer _tokenizer = new();

        public HtmlElement Parse(string html)
        {
            var root = new DivElement();
            var stack = new Stack<HtmlElement>();
            stack.Push(root);

            foreach (var token in _tokenizer.Tokenize(html))
            {
                var current = stack.Peek();

                if (token.StartsWith("<div"))
                {
                    var div = new DivElement { Styles = ExtractStyles(token) };
                    current.Children.Add(div);
                    stack.Push(div);
                }
                else if (token.StartsWith("</div>"))
                {
                    if (stack.Count > 1) stack.Pop();
                }
                else if (token.StartsWith("<p"))
                {
                    var p = new ParagraphElement { Styles = ExtractStyles(token) };
                    current.Children.Add(p);
                    stack.Push(p);
                }
                else if (token.StartsWith("</p>"))
                {
                    if (stack.Count > 1) stack.Pop();
                }
                else if (!token.StartsWith("<"))
                {
                    if (stack.Peek() is ParagraphElement paragraph)
                        paragraph.Text += token.Trim();
                    else
                        current.Children.Add(new ParagraphElement { Text = token.Trim() });
                }
            }

            return root;
        }

        private Dictionary<string, string> ExtractStyles(string tag)
        {
            var match = Regex.Match(tag, @"style\s*=\s*['""]([^'""]+)['""]", RegexOptions.IgnoreCase);
            return match.Success ? _styleInterpreter.Parse(match.Groups[1].Value) : new();
        }
    }
}
