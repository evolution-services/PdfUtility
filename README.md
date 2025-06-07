# PdfUtility

Open Source PDF Generator

**PdfUtility** is a library written in **.NET Core** that allows you to generate **PDF** files directly from **custom HTML** content, without using external libraries. Designed to be lightweight, robust and extensible, it is ideal for generating reports, invoices, contracts and business documents directly from HTML.

---

## ✨ Main Features

- ✅ Pure PDF generation, without third-party libraries
- ✅ Basic HTML support: `<div>`, `<p>`, `<table>`, `<tr>`, `<td>`
- ✅ Inline styles interpretation (`font-size`, `color`, etc.)
- ✅ Visitor pattern rendering pattern
- ✅ Modular architecture for future expansion

```markdown
PdfUtility/
├── Html/
│   ├── HtmlParser.cs
│   ├── HtmlTokenizer.cs
│   ├── StyleInterpreter.cs
│   ├── HtmlElement.cs
│   └── Elements/
│       ├── DivElement.cs
│       ├── ParagraphElement.cs
│       ├── TableElement.cs
│       ├── TableRowElement.cs
│       └── TableCellElement.cs
├── Pdf/
│   ├── PdfDocument.cs
│   ├── PdfRenderer.cs
│   └── interfaces/
│       └── IPdfElementVisitor.cs
├── PdfGenerator.cs
```
---

## 📦 Installation

The project is currently local. To use:

```bash
git clone https://github.com/evolution-services/PdfUtility.git
```

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
