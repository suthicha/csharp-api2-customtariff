using ClosedXML.Excel;
using CustomTariff.Models;
using DocumentFormat.OpenXml;
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
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
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

        private Boolean CheckDbNullRow(Object value)
        {
            if (value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
                return false;
            else
                return true;
        }
    }
}