using System.Dynamic;
using System.Text;
using Newtonsoft.Json;
using PromAdmin.Utilidades.Interfaces;
using Syncfusion.Drawing;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace PromAdmin.Utilidades.Servicios;

public class GenerarPdf : IGenerarPdf
{
    public byte[] Generar()
    {
        
        var htmlText = PlantillaPorNombre("MBTIResultado");
        
        //var expando = JsonConvert.DeserializeObject<ExpandoObject>(modelData);

        //var sObject = BuildScriptObject(expando);
        var templateCtx = new Scriban.TemplateContext();
        //templateCtx.PushGlobal(sObject);
        var template = Scriban.Template.Parse(htmlText);
        var result = template.Render(templateCtx);
        
        //Initialize HTML to PDF converter with Blink rendering engine
        
        var htmlConverter = new HtmlToPdfConverter();
        var baseUrl = Path.GetFullPath(@"Plantillas/");
        var blinkConverterSettings = new BlinkConverterSettings
        {
            PdfPageSize =  PdfPageSize.A4,
            Margin = new PdfMargins(){All = 0},
            Scale = 1.0f
        };
        blinkConverterSettings.CommandLineArguments.Add("--no-sandbox");
        blinkConverterSettings.CommandLineArguments.Add("--disable-setuid-sandbox");
        htmlConverter.ConverterSettings = blinkConverterSettings;
        try
        {
            var document = htmlConverter.Convert(result, baseUrl);
            //Convert HTML string to PDF

            var output = new MemoryStream();

            //Save and close the PDF document 
            document.Save(output);
            document.Close(true);
            output.Position = 0;
            var pdfBytes = output.ToArray();
            output.Close();

            return pdfBytes;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private string PlantillaPorNombre(string nombrePlantilla)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Plantillas", $"{nombrePlantilla}.html");
        var htmlContent = System.IO.File.ReadAllText(filePath);

        return htmlContent;

    }
}