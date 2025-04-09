namespace WebAppVendingMachin.Services
{
    using Aspose.Words.Drawing;
    using iText.IO.Image;
    using iText.Kernel.Pdf;
    using iText.Layout;
    using WebAppVendingMachin.Models;
    using Xceed.Words.NET;

    public static class CreateReport
    {
        public static byte[] GetReportPDF(Report report)
        {
            var fileTemplate = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "Template.docx");
            var pdfFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "TempFilePDF.pdf");
            using (var wordStream = new MemoryStream())
            {
                using (var document = DocX.Load(fileTemplate))
                {

                    document.ReplaceText("[Date]", DateTime.Now.ToString("D"));
                    document.ReplaceText("[CompnayName]", report.Company.Name);
                    document.ReplaceText("[NameMachin]", report.VendingMachin.Name);
                    document.ReplaceText("[ModelMachin]", report.VendingMachin.Model.Name);
                    document.ReplaceText("[IdMachin]", report.VendingMachinId.ToString());
                    document.ReplaceText("[Price]", report.VendingMachin.PriceInMounth.ToString());
                    document.ReplaceText("[DateStart]", report.DateStart.ToString("d"));
                    document.ReplaceText("[DateEnd]", report.DateEnd.ToString("d"));
                    document.ReplaceText("[Adress]", report.Company.Adress);
                    document.ReplaceText("[Contacts]", report.Company.ContactCompany);
                    document.SaveAs(wordStream);
                }
                wordStream.Seek(0, SeekOrigin.Begin);
                var wordDoc = new Aspose.Words.Document(wordStream);
                using (var pdf = new MemoryStream())
                {
                    wordDoc.Save(pdf, Aspose.Words.SaveFormat.Pdf);
                    return pdf.ToArray();
                }
            }
        }

        public static byte[] InsertSign(byte[] file, byte[] sign)
        {
            using (var fileStream = new MemoryStream(file))
            using (var newFile = new MemoryStream())
            using (var pdfRider = new PdfReader(fileStream))
            using (var pdfWriter = new PdfWriter(newFile))
            using (var pdfDocumnet = new PdfDocument(pdfRider, pdfWriter))
            {
                var document = new Document(pdfDocumnet);

                var image = new iText.Layout.Element.Image(ImageDataFactory.Create(sign));
                image.ScaleToFit(100, 100);
                image.SetFixedPosition(pdfDocumnet.GetNumberOfPages(), 60, 60);
                document.Add(image);
                document.Close();
                return newFile.ToArray();
            }
        }
    }
}
