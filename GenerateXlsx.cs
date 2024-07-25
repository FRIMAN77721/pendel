using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using pendel;


namespace pendel
{
    class GenerateXlsx
    {
        public static void CreateResultsU(List<Person> ResultsP, List<Person> ResultsG )
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("PEN");
                var sheet2 = package.Workbook.Worksheets.Add("GSP");
                sheet.Cells["A1"].Value = "Район";
                sheet.Cells["B1"].Value = "Фамилия";
                sheet.Cells["C1"].Value = "Имя";
                sheet.Cells["D1"].Value = "Отчество";
                sheet.Cells["E1"].Value = "Снилс";
                sheet.Cells["F1"].Value = "Дата";
                sheet.Cells["G1"].Value = "Операция";
                sheet.Cells["H1"].Value = "ID";

                sheet2.Cells["A1"].Value = "Район";
                sheet2.Cells["B1"].Value = "Фамилия";
                sheet2.Cells["C1"].Value = "Имя";
                sheet2.Cells["D1"].Value = "Отчество";
                sheet2.Cells["E1"].Value = "Снилс";
                sheet2.Cells["F1"].Value = "Дата";
                sheet2.Cells["G1"].Value = "Операция";
                sheet2.Cells["H1"].Value = "ID";


                int row = 2;

                foreach (var item in ResultsP)
                {
                    int col = 1;
                    sheet.Cells[row, col].Value = item.RA;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.FA;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.IM;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.OT;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.SNILS;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.DATE;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.NP;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.ID;
                    sheet.Column(col).Width = 20;
                    row++;
                }
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                int row2 = 2;
                foreach (var item in ResultsG)
                {
                    int col = 1;
                    sheet2.Cells[row2, col].Value = item.RA;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.FA;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.IM;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.OT;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.SNILS;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.DATE;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.NP;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value = item.ID;
                    sheet2.Column(col).Width = 20;
                    row2++;
                }
                sheet2.Cells[sheet2.Dimension.Address].AutoFitColumns();
                package.SaveAs(Environment.CurrentDirectory + @"\удаленные " + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + ".xlsx");

            }
        }

        public static void CreateXlsxD(List<Person> ResultsP, List<Person> ResultsG ) 
        {
            using (var package = new ExcelPackage())
            {
                var sheet = package.Workbook.Worksheets.Add("PEN");
                var sheet2 = package.Workbook.Worksheets.Add("GSP");
                sheet.Cells["A1"].Value = "Фамилия";
                sheet.Cells["B1"].Value = "Имя";
                sheet.Cells["C1"].Value = "Отчество";
                sheet.Cells["D1"].Value = "Снилс";
                sheet.Cells["E1"].Value = "Район_М";
                sheet.Cells["F1"].Value = "Район_МО";
                sheet.Cells["G1"].Value = "Операция_М";
                sheet.Cells["H1"].Value = "Операция_МО";

                sheet2.Cells["A1"].Value = "Фамилия";
                sheet2.Cells["B1"].Value = "Имя";
                sheet2.Cells["C1"].Value = "Отчество";
                sheet2.Cells["D1"].Value = "Снилс";
                sheet2.Cells["E1"].Value = "Район_М";
                sheet2.Cells["F1"].Value = "Район_МО";
                sheet2.Cells["G1"].Value = "Операция_М";
                sheet2.Cells["H1"].Value = "Операция_МО";


                int row = 2;

                foreach (var item in ResultsP)
                {
                    int col = 1;
                    sheet.Cells[row, col].Value = item.FA;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.IM;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.OT;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.SNILS;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.RA;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.RA2;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.NP;
                    sheet.Column(col).Width = 20;
                    col++;
                    sheet.Cells[row, col].Value = item.NP2;
                    sheet.Column(col).Width = 20;

                    if (item.NP != "ПРИ" && item.NP2!= "ПРИ" )
                    {
                        sheet.Row(row).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        sheet.Row(row).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                    }
                    row++;
                }
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                int row2 = 2;
                foreach (var item in ResultsG)
                {
                    int col = 1;
                    sheet2.Cells[row2, col].Value =item.FA;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.IM;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.OT;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.SNILS;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.RA;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.RA2;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.NP;
                    sheet2.Column(col).Width = 20;
                    col++;
                    sheet2.Cells[row2, col].Value =item.NP2;
                    sheet2.Column(col).Width = 20;
                    //окрашивание строки в экселе 
                    if (item.NP != "ПРИ" && item.NP2 != "ПРИ")
                    {
                        sheet2.Row(row2).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        sheet2.Row(row2).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                    }
                    row2++;
                }
                sheet2.Cells[sheet2.Dimension.Address].AutoFitColumns();
                package.SaveAs(Environment.CurrentDirectory + @"\ДУБЛИ " + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + ".xlsx");

            }







        }


    }
}
