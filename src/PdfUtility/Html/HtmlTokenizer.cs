namespace PdfUtility.Html
{
    public class HtmlTokenizer
    {
        public IEnumerable<string> Tokenize(string html)
        {
            int pos = 0;
            while (pos < html.Length)
            {
                if (html[pos] == '<')
                {
                    int end = html.IndexOf('>', pos);
                    if (end == -1) break;
                    yield return html.Substring(pos, end - pos + 1);
                    pos = end + 1;
                }
                else
                {
                    int end = html.IndexOf('<', pos);
                    if (end == -1) end = html.Length;
                    yield return html.Substring(pos, end - pos);
                    pos = end;
                }
            }
        }
    }
}
