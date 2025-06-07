using PdfUtility.Html;
using PdfUtility.Html.Elements;
using PdfUtility.Pdf.Interfaces;

namespace PdfUtility.Pdf
{
    public class PdfRenderer : IPdfElementVisitor
    {
        private readonly PdfDocument _doc;
        private float _cursorY = 800;
        private float _currentX = 50;

        public PdfRenderer(PdfDocument doc)
        {
            _doc = doc;
        }

        public void Render(HtmlElement root)
        {
            root.Accept(this);
        }

        public void Visit(ParagraphElement paragraph)
        {
            var fontSize = paragraph.Styles.TryGetValue("font-size", out var fs) ? float.Parse(fs.Replace("px", "").Replace("pt", "")) : 12f;
            var text = paragraph.Text;

            string content = $"BT /F1 {fontSize} Tf 50 {_cursorY} Td ({text}) Tj ET";
            _doc.AddObject($"<< /Length {content.Length} >>\nstream\n{content}\nendstream");
            _cursorY -= fontSize + 5;
        }

        public void Visit(DivElement div)
        {
            foreach (var child in div.Children)
                child.Accept(this);
        }

        public void Visit(TableElement table)
        {
            foreach (var row in table.Rows)
            {
                row.Accept(this);
            }
        }

        public void Visit(TableRowElement row)
        {
            _currentX = 50;
            float cellWidth = 100;
            float maxHeight = 0;

            foreach (var cell in row.Cells)
            {
                VisitCellWithContext(cell, _currentX);
                _currentX += cellWidth;

                if (cell.Styles.TryGetValue("font-size", out var fs))
                {
                    if (float.TryParse(fs.Replace("px", "").Replace("pt", ""), out float sz))
                        maxHeight = Math.Max(maxHeight, sz);
                }
                else
                {
                    maxHeight = Math.Max(maxHeight, 10);
                }
            }

            _cursorY -= maxHeight + 10;
        }

        private void VisitCellWithContext(TableCellElement cell, float x)
        {
            var fontSize = cell.Styles.TryGetValue("font-size", out var fs)
                ? float.Parse(fs.Replace("px", "").Replace("pt", ""))
                : 10f;

            var text = cell.Text;

            string content = $"BT /F1 {fontSize} Tf {x} {_cursorY} Td ({text}) Tj ET";
            _doc.AddObject($"<< /Length {content.Length} >>\nstream\n{content}\nendstream");

            foreach (var child in cell.Children)
                child.Accept(this);
        }

        public void Visit(TableCellElement cell)
        {
            VisitCellWithContext(cell, _currentX);
        }
    }
}
