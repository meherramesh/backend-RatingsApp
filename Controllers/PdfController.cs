using Microsoft.AspNetCore.Mvc;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace RatingsApp.Controllers
{
    [ApiController]
    [Route("api/pdf")]
    public class PdfController : ControllerBase
    {
        private readonly IConverter _converter;
        private readonly IWebHostEnvironment _env;

        public PdfController(IConverter converter, IWebHostEnvironment env)
        {
            _converter = converter;
            _env = env;
        }

        // ================================
        // 1️⃣ SINGLE PAGE INVOICE
        // ================================
        [HttpGet("single")]
        public IActionResult GenerateSingle()
        {
            var html = LoadInvoice("Invoice1");
            return GeneratePdf(html, "SingleInvoice.pdf");
        }

        // ================================
        // 2️⃣ SAME INVOICE 5 TIMES
        // ================================
        [HttpGet("multiple")]
        public IActionResult GenerateMultiple()
        {
            var singleHtml = LoadInvoice("Invoice1");

            var finalHtml = "";

            for (int i = 0; i < 5; i++)
            {
                finalHtml += singleHtml;

                if (i < 4)
                    finalHtml += "<div style='page-break-after: always;'></div>";
            }

            return GeneratePdf(finalHtml, "FiveInvoices.pdf");
        }

        // ================================
        // 3️⃣ COMBINE TWO DIFFERENT INVOICES
        // ================================
        [HttpGet("combine")]
        public IActionResult GenerateCombined()
        {
            var invoice1 = LoadInvoice("Invoice1");
            var invoice2 = LoadInvoice("Invoice2");

            var finalHtml = invoice1 +
                            "<div style='page-break-after: always;'></div>" +
                            invoice2;

            return GeneratePdf(finalHtml, "CombinedInvoices.pdf");
        }

        // ================================
        // COMMON HELPER METHOD
        // ================================
        private string LoadInvoice(string folderName)
        {
            var rootPath = _env.ContentRootPath;

            var htmlPath = Path.Combine(rootPath, "Templates", folderName, "invoice.html");
            var cssPath = Path.Combine(rootPath, "Templates", folderName, "style.css");

            var html = System.IO.File.ReadAllText(htmlPath);
            var css = System.IO.File.ReadAllText(cssPath);

            return html.Replace("</head>", $"<style>{css}</style></head>");
        }

        private IActionResult GeneratePdf(string htmlContent, string fileName)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait,
            },
                Objects = {
                new ObjectSettings() {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            var pdf = _converter.Convert(doc);

            return File(pdf, "application/pdf", fileName);
        }
    }

}
