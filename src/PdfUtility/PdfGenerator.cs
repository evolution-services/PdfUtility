using PdfUtility.Html;
using PdfUtility.Pdf;

namespace PdfUtility
{
    public class PdfGenerator
    {
        public byte[] GenerateFromHtml(string html)
        {
            var parser = new HtmlParser();
            var root = parser.Parse(html);

            var doc = new PdfDocument();
            var renderer = new PdfRenderer(doc);
            renderer.Render(root);

            return doc.Save();
        }
    }
}
