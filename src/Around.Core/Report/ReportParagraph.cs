using System.Collections.Generic;
using Around.Core.Entities;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Around.Core.Report
{
    public class ReportParagraph
    {
        private readonly Cheque _cheque;
        public ReportParagraph(Cheque cheque)
        {
            _cheque = cheque;
        }

        public IBlockElement Render()
        {
            List<Cell> valueCells = GetValueCells();
            List<Cell> headerCells = GetHeaderCells();
            var table = new Table(headerCells.Count);
            table.SetWidth(510f);

            foreach (Cell cell in valueCells)
            {
                cell.AddStyle(SetValueNeurocheckTableStyle());
                table.AddCell(cell);
            }

            foreach (Cell cell in headerCells)
            {
                cell.AddStyle(SetHeaderNeurocheckTableStyle());
                table.AddCell(cell);
            }

            return table;
        }

        private List<Cell> GetHeaderCells()
        {
            return new List<Cell>
            {
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph())
                    .SetBorderRight(Border.NO_BORDER)
            };
        }

        private List<Cell> GetValueCells()
        {
            return new List<Cell>
            {
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph()),
                new Cell()
                    .Add(new Paragraph())
                    .SetBorderRight(Border.NO_BORDER)
            };
        }

        public Style SetHeaderNeurocheckTableStyle()
        {
            return new Style()
                .SetBold()
                .SetFontSize(10)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetTextAlignment(TextAlignment.LEFT)
                .SetPaddingLeft(20)
                .SetBorder(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f))
                .SetVerticalAlignment(VerticalAlignment.TOP);
        }

        public Style SetValueNeurocheckTableStyle()
        {
            return new Style()
                .SetFontSize(14)
                .SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(84, 88, 87)))
                .SetPaddingLeft(20f)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetMarginLeft(75f)
                .SetMinWidth(75f)
                .SetBorder(Border.NO_BORDER)
                .SetBorderRight(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(180, 182, 177)), 0.5f));
        }


    }
}
