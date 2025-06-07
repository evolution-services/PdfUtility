using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Html.Elements
{
    public class TableRowElement : HtmlElement
    {
        public List<TableCellElement> Cells { get; set; } = new();
        public override void Accept(IPdfElementVisitor visitor)
            => visitor.Visit(this);
    }
}
