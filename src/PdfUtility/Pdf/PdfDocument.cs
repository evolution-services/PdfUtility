using System.Text;

namespace PdfUtility.Pdf
{
    public class PdfDocument
    {
        private readonly List<string> _objects = new();
        private int _objCount = 1;
        private readonly StringBuilder _builder = new();

        public void AddObject(string content)
        {
            _builder.AppendLine($"{_objCount++} 0 obj");
            _builder.AppendLine(content);
            _builder.AppendLine("endobj");
        }

        public byte[] Save()
        {
            var final = new StringBuilder();
            final.AppendLine("%PDF-1.4");
            final.Append(_builder);
            final.AppendLine("%%EOF");
            return Encoding.ASCII.GetBytes(final.ToString());
        }
    }
}
