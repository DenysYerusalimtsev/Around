using System;
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
        public Task RenderAsync(Stream stream, Cheque cheque)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            return Task.Run(() => ConstructReport(stream, cheque));
        }

        private void ConstructReport(Stream stream, Cheque cheque)
        {
            using (var writer = new PdfWriter(stream))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4))
            {
                writer.SetCloseStream(false);

                document.Add(new HeaderSection().Render())
                    .Add(new ReportParagraph().Render());

                SetDocumentInfo(pdf.GetDocumentInfo());
            }
        }

        private void SetDocumentInfo(PdfDocumentInfo documentInfo)
        {
            documentInfo
                .SetCreator("Denis Yerusalimtsev")
                .SetSubject("App report")
                .SetTitle("Cheque");
        }
    }
}
