using System.Dynamic;
using System.Text;
using Newtonsoft.Json;
using PromAdmin.Utilidades.Interfaces;

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
        var blinkConverterSettings = new BlinkConverterSettings()
        {
            //PdfPageSize = new Syncfusion.Drawing.SizeF(500, 500),
            ViewPortSize = new Syncfusion.Drawing.Size(595, 842),
            Margin = new PdfMargins() { All = 0 }
        };

        htmlConverter.ConverterSettings = blinkConverterSettings;

        try
        {
            var document = htmlConverter.Convert(result, "Plantillas/");
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


        // var conversor = new HtmlToPdfConverter();
        //
        // var blinkConverterSettings = new BlinkConverterSettings();
        //
        // var document = conversor.Convert(htmlText);
        // // using(PdfDocument document=conversor.Convert())
        //
        //
        //
        //
        // return document;
    }

    private string PlantillaPorNombre(string nombrePlantilla)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Plantillas", $"{nombrePlantilla}.html");
        var htmlContent = System.IO.File.ReadAllText(filePath);

        return htmlContent;

    }
}