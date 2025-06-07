using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Html.Elements
{
    public class TableElement : HtmlElement
    {
        public List<TableRowElement> Rows { get; set; } = new();
        public override void Accept(IPdfElementVisitor visitor)
            => visitor.Visit(this);
    }
}
