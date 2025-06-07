using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Html.Elements
{
    public class TableCellElement : HtmlElement
    {
        public string Text { get; set; } = string.Empty;
        public override void Accept(IPdfElementVisitor visitor)
            => visitor.Visit(this);
    }
}
