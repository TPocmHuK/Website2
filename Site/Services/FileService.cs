using iText.Kernel.Pdf;
using SautinSoft.Document;
using Spire.Xls;

namespace Site.Services
{
    public class FileService
    {
        public static void runConvertFileToPdf(string full_file_name)
        {
            string full_path = Path.GetFullPath(full_file_name);
            string ext = Path.GetExtension(full_path);
            string file_name_pdf = Path.GetDirectoryName(full_path) + "\\convert_file_" + Path.GetFileNameWithoutExtension(full_path) + "_.pdf";

            switch (ext)
            {
                case ".doc":
                case ".docx":
                    var appWord = new Microsoft.Office.Interop.Word.Application();
                    appWord.Visible = false;
                    // appWord.DisplayAlerts = False;
                    if (appWord.Documents != null)
                    {
                        //    yourDoc is your word document
                        var wordDocument = appWord.Documents.Open(full_path);

                        if (wordDocument != null)
                        {
                            wordDocument.ExportAsFixedFormat(file_name_pdf, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
                            //wordDocument.Close(false, "", false);
                            wordDocument.Close();
                        }
                        appWord.Quit();
                    }
                    break;
                case ".xls":
                case ".xlsx":
                    var appExel = new Microsoft.Office.Interop.Excel.Application();
                    appExel.Visible = false;
                    if (appExel.Workbooks != null)
                    {
                        var excelDocument = appExel.Workbooks.Open(full_path);
                        if (excelDocument != null)
                        {
                            excelDocument.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, file_name_pdf);
                            excelDocument.Close(); //Close document

                        }

                        appExel.Quit(); //Important: When you forget this Excel keeps running in the background
                    }
                    break;
                default:
                    return;
            }
            return;
        }

        public static int CountPages(string fullPathName)
        {
            int pagesCounter = 0;

            if (Path.GetExtension(fullPathName).Contains(".docx"))
            {
                DocumentCore dc = DocumentCore.Load(fullPathName);
                pagesCounter = Convert.ToInt32(dc?.Document.Properties.BuiltIn[BuiltInDocumentProperty.Pages]);
                Console.WriteLine(fullPathName);
                Console.WriteLine(pagesCounter);
            }

            if (Path.GetExtension(fullPathName).Contains(".doc"))
            {
                DocumentCore dc = DocumentCore.Load(fullPathName);
                dc.CalculateStats();
                pagesCounter = Convert.ToInt32(dc?.Document.Properties.BuiltIn[BuiltInDocumentProperty.Pages]);
                Console.WriteLine(fullPathName);
                Console.WriteLine(pagesCounter);
            }

            if (Path.GetExtension(fullPathName).Contains(".pdf"))
            {
                PdfDocument pdfDocument = new PdfDocument(new PdfReader(fullPathName));
                pagesCounter = pdfDocument.GetNumberOfPages();
            }

            if (Path.GetExtension(fullPathName).Contains(".xls"))
            {
                Workbook wb = new Workbook();
                wb.LoadFromFile(fullPathName);
                var pageInfoList = wb.GetSplitPageInfo();
                int sheetCount = pageInfoList.Count;
                int pageCount = 0;
                Console.WriteLine(sheetCount);
                for (int i = 0; i < sheetCount; i++)
                {
                    pageCount += pageInfoList[i].Count;
                    Console.WriteLine(pageCount);
                    pagesCounter = pageCount;
                }
            }

            return pagesCounter;
        }
    }
}
