using System.IO;
using System.Threading.Tasks;
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

        private T ConstructReport<T>(T stream, Cheque cheque)
            where T : Stream
        {
            using (var writer = new PdfWriter(stream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4))
            {
                writer.SetCloseStream(false);

                document.Add(new HeaderSection(cheque).Render())
                    .Add(new ReportParagraph(cheque).Render());
                SetDocumentInfo(pdf.GetDocumentInfo());

                stream.Position = 0;

                return stream;
            }
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