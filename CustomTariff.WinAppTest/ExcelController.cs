using ClosedXML.Excel;
using CustomTariff.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTariff.WinAppTest
{
    public class ExcelController
    {
        private CultureInfo cultureInfo = new CultureInfo("en-US");

        public DataTable Read(string sourceFile)
        {
            //Create a new DataTable.
            DataTable dt = new DataTable();

            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(sourceFile))
            {
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(1);

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        //Add rows to DataTable.
                        dt.Rows.Add();
                        int i = 0;

                        var cellCount = row.CellCount();

                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            var cellXML = row.Cell(col + 1);
                            var cellValue = string.Empty;

                            if (cellXML.DataType == XLCellValues.DateTime)
                            {
                                cellValue = ((DateTime)row.Cell(col + 1).Value).ToString("yyyy.MM.dd", cultureInfo);
                            }
                            else
                                cellValue = row.Cell(col + 1).RichText.ToString();

                            dt.Rows[dt.Rows.Count - 1][i] = cellValue;
                            i++;
                        }

                        //foreach (IXLCell cell in row.Cells())
                        //{
                        //    if (string.IsNullOrEmpty(cell.RichText.ToString()))
                        //        Console.WriteLine(dt.Rows[dt.Rows.Count - 1][i].ToString());

                        //    dt.Rows[dt.Rows.Count - 1][i] = cell.RichText;
                        //    i++;
                        //}
                    }
                }
                return dt;
            }
        }

        public DataTable ReadSheets(string sourceFile)
        {
            //Create a new DataTable.
            DataTable dt = new DataTable();

            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(sourceFile))
            {
                var totalCount = workBook.Worksheets.Count();

                for (int i = 0; i < totalCount; i++)
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet(i + 1);

                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            if (i == 0)
                            {
                                foreach (IXLCell cell in row.Cells())
                                {
                                    dt.Columns.Add(cell.Value.ToString(), typeof(String));
                                }
                                dt.Columns.Add("SheetName", typeof(String));
                                firstRow = false;
                            }
                            else
                                firstRow = false;
                        }
                        else
                        {
                            //Add rows to DataTable.
                            dt.Rows.Add();
                            int j = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                if (cell.DataType == XLCellValues.DateTime)
                                {
                                    var cellDateValue = ((DateTime)cell.Value).ToString("yyyy.MM.dd", cultureInfo);
                                    dt.Rows[dt.Rows.Count - 1][j] = cellDateValue.Replace(".", "");
                                }
                                else
                                {
                                    var cellValue = cell.RichText.ToString().Replace("ex", " ex");
                                    // cellValue = cellValue.Replace(Environment.NewLine, "|").Replace(" ", "|").Replace(" ", "").Replace(".", "");
                                    dt.Rows[dt.Rows.Count - 1][j] = cellValue;
                                }

                                j++;
                            }
                            dt.Rows[dt.Rows.Count - 1]["SheetName"] = workSheet.Name;
                        }
                    }
                }

                return dt;
            }
        }

        public List<ProductModel> ConvertToObjProduct(DataTable table)
        {
            var productObj = new List<ProductModel>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var dr = table.Rows[i];
                productObj.Add(new ProductModel
                {
                    companyCode = dr[0].ToString(),
                    divisionCode = dr[1].ToString(),
                    section = dr[2].ToString(),
                    formality = dr[3].ToString(),
                    typeofProduct = dr[4].ToString(),
                    partname = dr[5].ToString(),
                    spec = dr[6].ToString(),
                    fullPartname = dr[7].ToString(),
                    madeby = dr[8].ToString(),
                    unit = dr[9].ToString(),
                    pdtDescriptionTH = dr[10].ToString(),
                    tariffCode = dr[11].ToString(),
                    tariffSeq = dr[12].ToString(),
                    tariffUnit = dr[13].ToString(),
                    dutyRate = Convert.ToDouble(dr[14]),
                    needLicense = CheckDbNullRow(dr[15]),
                    ministry = dr[16].ToString(),
                    pdtClass = dr[17].ToString(),
                    customsFunc = dr[18].ToString(),
                    usedForMachine = dr[19].ToString(),
                    cropPlanningRemark = dr[20].ToString(),
                    filter1 = dr[21].ToString(),
                    filter2 = dr[22].ToString(),
                    filter3 = dr[23].ToString(),
                    filter4 = dr[24].ToString(),
                    filter5 = dr[25].ToString(),
                    filter6 = dr[26].ToString(),
                    remark1 = dr[27].ToString(),
                    remark2 = dr[28].ToString(),
                    operationCode = dr[30].ToString(),
                    programCode = dr[31].ToString(),
                    createBy = "SYSTEM",
                    createDate = DateTime.ParseExact(dr[29].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture),
                    updateBy = "",
                    updateDate = DateTime.Now
                });
            }

            return productObj;
        }

        private List<string> separateTariff(string content)
        {
            content = RemoveLineEndings(content);
            content = content.Replace(" ", "").Replace(" ", "").Replace(".", "");

            var lstTariff = new List<string>();

            while (content.Length > 0)
            {
                string padContent = "";
                string padText = content.Substring(0, 2);
                int delLength = 0;

                if (padText == "ex")
                {
                    padContent = content.Substring(0, 10);
                    delLength = 10;
                }
                else
                {
                    padContent = content.Substring(0, 8);
                    delLength = 8;
                }

                lstTariff.Add(padContent);
                content = content.Remove(0, delLength);
            }
            return lstTariff;
        }

        public List<ProductNModel> ConvertToObjProductN(DataTable table)
        {
            var objProducts = new List<ProductNModel>();
            int currentId = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                if (string.IsNullOrEmpty(row[0].ToString()) &&
                    string.IsNullOrEmpty(row[1].ToString()))
                {
                    var preItem = objProducts.Find(q => q.id == currentId);
                    if (preItem == null) continue;

                    objProducts.Add(new ProductNModel()
                    {
                        id = preItem.id,
                        companyCode = preItem.companyCode,
                        divisionCode = preItem.divisionCode,
                        section = preItem.section,
                        formality = preItem.formality,
                        typeofProduct = preItem.typeofProduct,
                        fullPartname = preItem.fullPartname,
                        madeby = preItem.madeby,
                        unit = preItem.unit,
                        pdtDescriptionTH = preItem.pdtDescriptionTH,
                        pdtDescriptionAddOn = row[8].ToString(),
                        tariffCode = preItem.tariffCode,
                        tariffSeq = preItem.tariffSeq,
                        tariffUnit = preItem.tariffUnit,
                        dutyRate = preItem.dutyRate,
                        newTariffCode = row[13].ToString(),
                        newTariffSeq = row[14].ToString(),
                        newTariffUnit = row[15].ToString(),
                        newDutyRate = FixDutyRate(row[16])
                    });

                    continue;
                }

                objProducts.Add(new ProductNModel()
                {
                    id = i + 1,
                    companyCode = row[0].ToString(),
                    divisionCode = row[1].ToString(),
                    section = row[2].ToString(),
                    formality = row[3].ToString(),
                    typeofProduct = row[4].ToString(),
                    fullPartname = row[5].ToString(),
                    madeby = row[6].ToString(),
                    unit = row[7].ToString(),
                    pdtDescriptionTH = row[8].ToString(),
                    pdtDescriptionAddOn = "",
                    tariffCode = row[9].ToString(),
                    tariffSeq = row[10].ToString(),
                    tariffUnit = row[11].ToString(),
                    dutyRate = FixDutyRate(row[12]),
                    newTariffCode = row[13].ToString(),
                    newTariffSeq = row[14].ToString(),
                    newTariffUnit = row[15].ToString(),
                    newDutyRate = FixDutyRate(row[16])
                });

                currentId++;
            }

            return objProducts;
        }

        public List<ProductNModel> ConvertToObjProductN2(DataTable table)
        {
            var objProducts = new List<ProductNModel>();
            int currentId = 0;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                if (string.IsNullOrEmpty(row[0].ToString()) &&
                    string.IsNullOrEmpty(row[1].ToString()))
                {
                    var preItem = objProducts.Find(q => q.id == currentId);
                    if (preItem == null) continue;

                    objProducts.Add(new ProductNModel()
                    {
                        id = preItem.id,
                        companyCode = preItem.companyCode,
                        divisionCode = preItem.divisionCode,
                        section = preItem.section,
                        formality = preItem.formality,
                        typeofProduct = preItem.typeofProduct,
                        fullPartname = preItem.fullPartname,
                        madeby = preItem.madeby,
                        unit = preItem.unit,
                        pdtDescriptionTH = preItem.pdtDescriptionTH,
                        pdtDescriptionAddOn = row[4].ToString(),
                        tariffCode = preItem.tariffCode,
                        tariffSeq = preItem.tariffSeq,
                        tariffUnit = preItem.tariffUnit,
                        dutyRate = preItem.dutyRate,
                        newTariffCode = row[9].ToString(),
                        newTariffSeq = row[10].ToString(),
                        newTariffUnit = row[11].ToString(),
                        newDutyRate = FixDutyRate(row[12])
                    });

                    continue;
                }

                objProducts.Add(new ProductNModel()
                {
                    id = i + 1,
                    companyCode = row[0].ToString(),
                    divisionCode = row[1].ToString(),
                    section = "",
                    formality = "",
                    typeofProduct = "",
                    fullPartname = row[3].ToString(),
                    madeby = row[2].ToString(),
                    unit = "",
                    pdtDescriptionTH = row[4].ToString(),
                    pdtDescriptionAddOn = "",
                    tariffCode = row[5].ToString(),
                    tariffSeq = row[6].ToString(),
                    tariffUnit = row[7].ToString(),
                    dutyRate = FixDutyRate(row[8]),
                    newTariffCode = row[9].ToString(),
                    newTariffSeq = row[10].ToString(),
                    newTariffUnit = row[11].ToString(),
                    newDutyRate = FixDutyRate(row[12])
                });

                currentId++;
            }

            return objProducts;
        }

        private string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        public List<TariffModel> ConvertToObjTariff(DataTable table)
        {
            var tariffObj = new List<TariffModel>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                try
                {
                    var dr = table.Rows[i];
                    var tariffcode = dr[0].ToString();
                    var newTariffCode = dr[1].ToString();

                    if (tariffcode.Length > 0 && newTariffCode.Length > 0)
                    {
                        var splitTariff = separateTariff(newTariffCode);

                        for (int n = 0; n < splitTariff.Count; n++)
                        {
                            var tariffCotent = splitTariff[n];
                            tariffObj.Add(new TariffModel
                            {
                                TariffCode = tariffcode.Replace(".", ""),
                                NewTariffCode = tariffCotent.Replace("ex", ""),
                                Extension = tariffCotent.Contains("ex") ? "EX" : "",
                                Remark = dr[2].ToString(),
                                Length = tariffCotent.Replace("ex", "").Length
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return tariffObj;
        }

        private Boolean CheckDbNullRow(Object value)
        {
            if (value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
                return false;
            else
                return true;
        }

        private Double FixDutyRate(Object value)
        {
            if (value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
            {
                return 0;
            }
            else
                return Convert.ToDouble(value.ToString());
        }
    }
}