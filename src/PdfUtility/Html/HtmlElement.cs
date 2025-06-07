using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Html
{
    public abstract class HtmlElement
    {
        public List<HtmlElement> Children { get; set; } = new();
        public Dictionary<string, string> Styles { get; set; } = new();
        public abstract void Accept(IPdfElementVisitor visitor);
    }
}
