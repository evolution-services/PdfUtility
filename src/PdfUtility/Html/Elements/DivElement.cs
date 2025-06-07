using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Html.Elements
{
    public class DivElement : HtmlElement
    {
        public override void Accept(IPdfElementVisitor visitor)
            => visitor.Visit(this);
    }
}
