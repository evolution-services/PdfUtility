using PdfUtility.Html.Elements;

namespace PdfUtility.Pdf.Interfaces
{
    public interface IPdfElementVisitor
    {
        void Visit(ParagraphElement paragraph);
        void Visit(DivElement div);
        void Visit(TableElement table);
        void Visit(TableRowElement row);
        void Visit(TableCellElement cell);
    }
}
