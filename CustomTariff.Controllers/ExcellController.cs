using ClosedXML.Excel;
using System;
using System.IO;

namespace CustomTariff.Controllers
{
    public class ExcellController
    {
        private IXLWorksheet _worksheet;
        private XLWorkbook _workbook;
        private int _lastRow;

        public ExcellController()
        {
        }

        public void CreateWorkSheet(string sheetName)
        {
            _workbook = new XLWorkbook();
            _worksheet = _workbook.Worksheets.Add(sheetName);
        }

        public void CreateHeader(params string[] title)
        {
            for (int i = 0; i < title.Length; i++)
            {
                var colIndex = i + 1;
                _worksheet.Cell(1, colIndex).Value = title[i];
            }
            _lastRow++;
        }

        public void AddRow(params Object[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                var colIndex = i + 1;
                _worksheet.Cell(_lastRow + 1, colIndex).Value = data[i];
                _worksheet.Cell(_lastRow + 1, colIndex).DataType = XLCellValues.Text;

                if (colIndex == 11)
                {
                    _worksheet.Cell(_lastRow + 1, i + 1).Style.Alignment.WrapText = true;
                }
            }
            _lastRow++;
        }

        public void Save(string outputPath)
        {
            //if (File.Exists(outputPath))
            //    File.Delete(outputPath);

            _worksheet.Rows().AdjustToContents();
            _worksheet.Columns().AdjustToContents();
            _worksheet.Column(11).Width = 100;
            _workbook.SaveAs(outputPath);
        }
    }
}