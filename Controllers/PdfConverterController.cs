using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using ConvertApiDotNet;
using ConvertApiDotNet.Exceptions;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class PdfConverterController : Controller
{
    private const string ConvertApiSecret = "yourSecretAPI"; // ConvertAPI secret
    private readonly IWebHostEnvironment _hostingEnvironment;

    public PdfConverterController(IWebHostEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ConvertToPdf(IFormFile file)
    {
        try
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); // Create uploads folder if it doesn't exist

                // Save the uploaded Word document to a temporary file
                var tempFilePath = Path.Combine(uploadsFolder, "temp_document.docx");

                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Convert Word document to PDF using ConvertAPI
                var convertApi = new ConvertApi(ConvertApiSecret);

                var conversionTask = await convertApi.ConvertAsync("docx", "pdf", new ConvertApiFileParam(tempFilePath));
                var fileSaved = await conversionTask.Files.SaveFilesAsync(uploadsFolder);

                // Get the converted PDF file path
                var pdfFilePath = fileSaved.FirstOrDefault().FullName;

                // Return the PDF file path
                return Json(new { filePath = "/uploads/converted_document.pdf" });
            }
            else
            {
                return BadRequest("Please upload a Word document.");
            }
        }
        catch (ConvertApiException ex)
        {
            return StatusCode(500, $"ConvertAPI error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error during conversion: {ex.Message}");
        }
    }
}
