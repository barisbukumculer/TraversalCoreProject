using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace TraversalCoreProject.Controllers
{
    public class PDFReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/"+"dosya1.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/dosya1.pdf","application/pdf","dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya3.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            string Arial_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");
            BaseFont bf = BaseFont.CreateFont(Arial_TFF, BaseFont.IDENTITY_H, true);
            Font f = new Font(bf, 12, Font.NORMAL);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal - Statik Müşteri Raporu\n\n", f);

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell(new Phrase("Müşteri Adı", f));
            pdfPTable.AddCell(new Phrase("Müşteri Soyadı", f));
            pdfPTable.AddCell(new Phrase("Müşteri TC Kimlik", f));

            pdfPTable.AddCell(new Phrase("Barış",f));
            pdfPTable.AddCell(new Phrase("Bükümcüler", f));
            pdfPTable.AddCell(new Phrase("123456789", f));

            pdfPTable.AddCell(new Phrase("Kemal", f));
            pdfPTable.AddCell(new Phrase("Yıldırım", f));
            pdfPTable.AddCell(new Phrase("123234234", f));
            
            pdfPTable.AddCell(new Phrase("Mehmet", f));
            pdfPTable.AddCell(new Phrase("Yılmaz", f));
            pdfPTable.AddCell(new Phrase("987654321", f));
         
            document.Add(pdfPTable);
            document.Close();
            return File("/PdfReports/dosya3.pdf", "application/pdf", "dosya3.pdf");
        }
    }
}
