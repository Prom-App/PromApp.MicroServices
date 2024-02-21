using System.Dynamic;
using Newtonsoft.Json;
using PromAdmin.Utilidades.Interfaces;
using Scriban.Runtime;
using SelectPdf;
using Syncfusion.HtmlConverter;
using PdfMargins = Syncfusion.Pdf.Graphics.PdfMargins;
using PdfPageSize = Syncfusion.Pdf.PdfPageSize;

namespace PromAdmin.Utilidades.Servicios;

public class GenerarPdf : IGenerarPdf
{
    public async Task<byte[]> ConvertirAPdf(string nombrePlantilla, string data)
    {
        var htmlText = PlantillaPorNombre(nombrePlantilla);

        var expando = JsonConvert.DeserializeObject<ExpandoObject>(data);
        var sObject = BuildScriptObject(expando!);
        var templateCtx = new Scriban.TemplateContext();
        templateCtx.PushGlobal(sObject);
        var template = Scriban.Template.Parse(htmlText);
        var result = template.Render(templateCtx);

        return await HtmlToPdfSelectPdf(result);
    }

    private Task<byte[]> HtmlToPdfSelectPdf(string html)
    {
        var converter = new HtmlToPdf {
            Options =
            {
                PdfPageSize = SelectPdf.PdfPageSize.A4,
                PdfPageOrientation = PdfPageOrientation.Portrait,
                WebPageWidth = 0,
                WebPageHeight = 0
            }
        };

        var baseUrl = Path.GetFullPath(@"Plantillas/");

        var doc = converter.ConvertHtmlString(html, baseUrl);

        var file=doc.Save();
        doc.Close();
        return Task.FromResult(file);
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
    
    private ScriptObject BuildScriptObject(ExpandoObject expando)
    {
        var dict = (IDictionary<string, object>)expando!;
        var scriptObject = new ScriptObject();

        foreach (var kv in dict)
        {
            var renamedKey = StandardMemberRenamer.Rename(kv.Key);
            if (renamedKey.Equals("items"))
            {

            }

            if (kv.Value is ExpandoObject expandoValue)
            {
                scriptObject.Add(renamedKey, BuildScriptObject(expandoValue));
            }
            else if (kv.Value is List<object>)
            {

                var itemsList = new List<ScriptObject>();
                foreach (var item in (kv.Value as List<object>)!)
                {
                    if (item is ExpandoObject expandoItem)
                    {
                        itemsList.Add(BuildScriptObject(expandoItem));
                    }
                }

                scriptObject.Add(renamedKey, itemsList);
            }
            else
            {
                scriptObject.Add(renamedKey, kv.Value);
            }
        }

        return scriptObject;
    }
}