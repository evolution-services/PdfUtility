namespace PdfUtility.Html
{
    public class StyleInterpreter
    {
        public Dictionary<string, string> Parse(string styleText)
        {
            var result = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(styleText))
                return result;

            var rules = styleText.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var rule in rules)
            {
                var parts = rule.Split(':', 2);
                if (parts.Length == 2)
                    result[parts[0].Trim().ToLower()] = parts[1].Trim();
            }
            return result;
        }
    }
}
