using System.Collections.Generic;
using Around.Core.Entities;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Around.Core.Report
{
    public class HeaderSection
    {
        private readonly Cheque _cheque;
        public HeaderSection(Cheque cheque)
        {
            _cheque = cheque;
        }

        public IBlockElement Render()
        {
            Table table = new Table(2)
                .SetWidth(510)
                .SetMarginLeft(18);

            foreach (ReportLine reportLine in Construct())
            {
                table.AddCell(new Cell()
                    .AddStyle(SetHeaderStyle())
                    .Add(reportLine.Label));

                table.AddCell(new Cell()
                    .AddStyle(SetNeurocheckStyle())
                    .Add(reportLine.Value));
            }

            return table;
        }

        private List<ReportLine> Construct()
        {
            Paragraph neurocheck = new Paragraph();
            Paragraph coma = new Paragraph(", ");
            Paragraph patientInfo = new Paragraph();

            return new List<ReportLine>
            {
                new ReportLine(patientInfo, neurocheck),
                new ReportLine(new Paragraph(),  new Paragraph())
            };
        }


        public Style SetHeaderStyle()
        {
            return new Style()
                .SetFontSize(14)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(0, 0, 0)))
                .SetBold()
                .SetWidth(420)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.LEFT);
        }

        public Style SetNeurocheckStyle()
        {
            return new Style()
                .SetBold()
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(0, 0, 0)))
                .SetWidth(100)
                .SetFontSize(14)
                .SetBorder(Border.NO_BORDER)
                .SetTextAlignment(TextAlignment.RIGHT);
        }
    }
}
