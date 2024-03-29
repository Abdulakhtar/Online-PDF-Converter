# Word to PDF Converter
This is a simple web application built with ASP.NET Core that allows users to convert Word documents (.docx) to PDF files. It provides two methods for conversion: one using Microsoft Word automation and another using the ConvertAPI library.

### Features
1) Converts Word documents to PDF format.
2) Supports both Microsoft Word automation and ConvertAPI for conversion.
3) Responsive web interface for easy file upload and conversion.

### Technologies Used
1) ASP.NET Core
2) C#
3) ConvertAPI for PDF conversion.
4) Microsoft Word automation for PDF conversion (optional).

### Prerequisites
Before running this application, ensure you have the following installed:

1) .NET SDK
2) Microsoft Word (if using Word automation)
3) ConvertAPI account with API secret key (if using ConvertAPI).

### For Convert API
1) Search which api you want to use such as doc-to-pdf at https://www.convertapi.com/doc-to-pdf#snippet=csharp
2) Select your programining language in which you want to work and read the github documentation provided there.
3) You can download you secret at https://www.convertapi.com/a

### Getting Started
1) Clone this repository to your local machine.
2) Use pdfConverter.sln file to see all of the controller and view related files.
3) Use pdfConverter.csproj to run the application locally.
4) Navigate to the project directory in the command line.
5) Run dotnet run to start the application.
6) Open your web browser and go to http://localhost:5000 (or whatever your local port is) to access the application.

### Usage
1) Upload a Word document (.docx) using the provided form.
2) Choose the conversion method (Microsoft Word or ConvertAPI).
3) Click the "Convert to PDF" button.
4) Once the conversion is complete, the PDF file will be available for download.

### Configuration
_ConvertAPI Configuration_
If you choose to use ConvertAPI for conversion, make sure to replace the placeholder API secret key in the PdfConverterController.cs file with your actual ConvertAPI secret key:

````

private const string ConvertApiSecret = "YOUR_CONVERTAPI_SECRET_KEY";

````

### License
This project is licensed under the MIT License - see the LICENSE file for details.

 
