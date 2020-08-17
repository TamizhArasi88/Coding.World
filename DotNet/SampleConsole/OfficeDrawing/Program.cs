using NPOI.HSSF.UserModel;
using NPOI.OpenXml4Net.OPC;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using NPOI.XSSF.UserModel;
using System.Drawing;
using System.IO;

namespace OfficeDrawing
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReadXlsxFile();
            //IWorkbook wb = new HSSFWorkbook();
            //HSSFSheet sheet1 = (HSSFSheet)wb.CreateSheet("new sheet");
            FileStream fis = new FileStream("XLSSummaryTemplate.xls", FileMode.Open);
            FileStream fileOut = new FileStream("workbook.xls", FileMode.Create);

            HSSFWorkbook wb = new HSSFWorkbook(fis);
            //HSSFSheet sheet1 = (HSSFSheet)wb.CreateSheet("new sheet");
            //drawSheet1(sheet1);

            wb.CloneSheet(0);
            HSSFSheet sheet1 = (HSSFSheet)wb.GetSheetAt(1);
            wb.SetSheetName(1, "PassCountSummary");
            drawSheet1(sheet1);

            wb.CloneSheet(0);
            HSSFSheet sheet2 = (HSSFSheet)wb.GetSheetAt(1);
            wb.SetSheetName(2, "PassCount");
            drawSheet1(sheet2);
            //wb.SetSheetHidden(0, true);

            HSSFSheet sheet = (HSSFSheet)wb.GetSheet("PassCount");
            if (sheet != null)
            {
                var index = wb.GetSheetIndex(sheet);
                wb.RemoveSheetAt(0);
            }

            wb.Write(fileOut);
            fileOut.Close();

            //    try (FileStream fis = new FileInputStream("./report_template.xls");
            //FileOutputStream fos = new FileOutputStream("./dump.xls")) {
            //    HSSFWorkbook wb = new HSSFWorkbook(fis);
            //    wb.write(fos);
            //}

            //// Create the workbook and sheets.
            //IWorkbook wb = new HSSFWorkbook();
            //HSSFSheet sheet1 = (HSSFSheet)wb.CreateSheet("new sheet");

            ////FillBackground(sheet1, wb);
            //drawSheet1(sheet1);
            //// Write the file out.
            //FileStream fileOut = new FileStream("workbook.xlsx", FileMode.Create);
            //wb.Write(fileOut);
            //fileOut.Close();

        }
        private static void drawSheet1(HSSFSheet sheet1)
        {
            // Create a row and size one of the cells reasonably large.
            HSSFRow row = (HSSFRow)sheet1.CreateRow(2);
            //row.Height = 2800;
            row.CreateCell(1);
            sheet1.SetColumnWidth(0, 3200);
            sheet1.SetColumnWidth(1, 3300);
            sheet1.SetColumnWidth(2, 3400);
            sheet1.SetColumnWidth(3, 3600);
            sheet1.SetColumnWidth(4, 3650);
            var r1 = sheet1.GetRow(2);
            r1.Height = 2800;

            // Create the drawing patriarch.  This is the top level container for
            // all shapes.
            HSSFPatriarch patriarch = (HSSFPatriarch)sheet1.CreateDrawingPatriarch();

            // Draw some lines and an oval.
            //drawLinesToCenter(patriarch);
            //drawManyLines(patriarch);
            //drawOval(patriarch);
            //drawPolygon(patriarch);

            // Draw a rectangle.
            HSSFRow row1 = (HSSFRow)sheet1.CreateRow(0);
            row1.Height = 350;
            row1.CreateCell(0).SetCellValue("Over");
            row1.GetCell(0).CellStyle.Alignment = HorizontalAlignment.Right;

            HSSFSimpleShape rect = patriarch.CreateSimpleShape(new HSSFClientAnchor(75, 60, 400, 220, 0, 4, 0, 4));
            rect.ShapeType = HSSFSimpleShape.OBJECT_TYPE_RECTANGLE;

            var color = ColorTranslator.FromHtml("13959168");
            rect.SetFillColor(color.R, color.G, color.B);
            rect.SetLineStyleColor(color.R, color.G, color.B);
        }

        private static void FillBackground(HSSFSheet sheet, HSSFWorkbook workbook)
        {
            var color = ColorTranslator.FromHtml("13959168");

            var tCs = workbook.CreateCellStyle();
            tCs.FillPattern = FillPattern.SolidForeground;
            tCs.FillForegroundColor = IndexedColors.Grey25Percent.Index;

            var tCs1 = workbook.CreateCellStyle();
            tCs1.FillPattern = FillPattern.SolidForeground;
            tCs1.FillForegroundColor = IndexedColors.Grey40Percent.Index;

            var tCs2 = workbook.CreateCellStyle();
            tCs2.FillPattern = FillPattern.SolidForeground;
            tCs2.FillForegroundColor = IndexedColors.Grey50Percent.Index;

            var tCs3 = workbook.CreateCellStyle();
            tCs3.FillPattern = FillPattern.SolidForeground;
            tCs3.FillForegroundColor = IndexedColors.Grey80Percent.Index;

            HSSFRow row1 = (HSSFRow)sheet.CreateRow(7);

            var tCell = row1.CreateCell(0);
            tCell.CellStyle = tCs;

            tCell = row1.CreateCell(1);
            tCell.CellStyle = tCs1;

            tCell = row1.CreateCell(2);
            tCell.CellStyle = tCs2;

            tCell = row1.CreateCell(3);
            tCell.CellStyle = tCs3;
        }

        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imageLocation);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            fs.Close();
            br.Close();
            return imageData;
        }

        //Adding Image 
        //byte[] data = File.ReadAllBytes(@"C:\Tamizh\VSSReports\Maps\3DHeader.png");
        //int pictureIndex = workbook.AddPicture(data, PictureType.PNG);
        //IDrawing drawing = worksheet.CreateDrawingPatriarch();
        //IClientAnchor anchor = crHelper.CreateClientAnchor();
        //anchor.Col1 = 0;//0 index based column
        //anchor.Row1 = 1;//0 index based row
        //IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
        //picture.Resize(20);

        public static void ReadXlsxFile()
        {
            string filePath = @"C:\Users\travich\Downloads\3D+Summary+Report_021618_045951.XLSX";
            FileStream fis = new FileStream(filePath, FileMode.Open, FileAccess.Read);


            //XSSFWorkbook wb = new XSSFWorkbook(fis);

            OPCPackage pkg = OPCPackage.Open(filePath);
            XSSFWorkbook xssfwb = new XSSFWorkbook(pkg);

            SXSSFWorkbook wb = new SXSSFWorkbook(xssfwb);
        }
    }
}
