using System.IO;
using Around.Core.Entities;
using Around.Core.Interfaces;
using Around.Core.Report;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;

namespace Around.Core.Services
{
    public class ReportRenderer : IReportRenderer
    {
        public MemoryStream Render(Cheque cheque)
        {
            var stream = new MemoryStream();
            return ConstructReport(stream, cheque);
        }

        private MemoryStream ConstructReport<T>(T stream, Cheque cheque)
            where T : MemoryStream
        {
            using (var writer = new PdfWriter(stream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4))
            {
                writer.SetCloseStream(false);
                SetDocumentInfo(pdf.GetDocumentInfo());
                document.Add(new HeaderSection(cheque).Render())
                    .Add(new ReportParagraph(cheque).Render());

            }
            var bytes = stream.ToArray();

            return new MemoryStream(bytes);
        }

        private void SetDocumentInfo(PdfDocumentInfo documentInfo)
        {
            documentInfo
                .SetCreator("Denis Yerusalimtsev")
                .SetSubject("Around cheque")
                .SetTitle("Cheque");
        }
    }
}