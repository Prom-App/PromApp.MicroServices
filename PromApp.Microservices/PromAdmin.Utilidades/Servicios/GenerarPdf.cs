using System.Dynamic;
using SelectPdf;
using Syncfusion.HtmlConverter;
using PdfMargins = Syncfusion.Pdf.Graphics.PdfMargins;
using PdfPageSize = Syncfusion.Pdf.PdfPageSize;

namespace PromAdmin.Utilidades.Servicios;

public class GenerarPdf 
{
    public byte[] ConvertirAPdf(string nombrePlantilla, ExpandoObject data)
    {
        var htmlText = PlantillaPorNombre(nombrePlantilla);

        //var expando = JsonConvert.DeserializeObject<ExpandoObject>(modelData);
        //var sObject = BuildScriptObject(data); //pendiente este metodo
        var templateCtx = new Scriban.TemplateContext();
        //templateCtx.PushGlobal(sObject);
        var template = Scriban.Template.Parse(htmlText);
        var result = template.Render(templateCtx);

        return HtmlToPdfSelectPdf(result);
    }

    private byte[] HtmlToPdfSelectPdf(string html)
    {
        var converter = new HtmlToPdf {
            Options =
            {
                PdfPageSize = SelectPdf.PdfPageSize.A4,
                PdfPageOrientation = SelectPdf.PdfPageOrientation.Portrait,
                WebPageWidth = 1024,
                WebPageHeight = 0
            }
        };

        var baseUrl = Path.GetFullPath(@"Plantillas/");

        var doc = converter.ConvertHtmlString(html, baseUrl);

        var file=doc.Save();
        doc.Close();
        return file;
    }
    
    private byte[] HtmlToPdfSyncFusion(string html)
    {
        var htmlConverter = new HtmlToPdfConverter();
        var baseUrl = Path.GetFullPath(@"Plantillas/");
        var blinkConverterSettings = new BlinkConverterSettings
        {
            PdfPageSize = PdfPageSize.A4,
            Margin = new PdfMargins { All = 0 },
            Scale = 1.0f
        };
        htmlConverter.ConverterSettings = blinkConverterSettings;
        var document = htmlConverter.Convert(html, baseUrl);

        var output = new MemoryStream();

        document.Save(output);
        document.Close(true);
        output.Position = 0;
        var pdfBytes = output.ToArray();
        output.Close();

        return pdfBytes;
    }

    private string PlantillaPorNombre(string nombrePlantilla)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantillas", $"{nombrePlantilla}.html");
        return File.ReadAllText(filePath);
    }
}