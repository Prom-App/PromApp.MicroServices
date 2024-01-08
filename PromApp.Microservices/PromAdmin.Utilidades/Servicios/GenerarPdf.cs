using PromAdmin.Utilidades.Interfaces;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;


namespace PromAdmin.Utilidades.Servicios;

public class GenerarPdf : IGenerarPdf
{
    public string Generar()
    {
        var conversor = new HtmlToPdfConverter();
        
        var htmlText = PlantillaPorNombre("MBTIResultado");
    

        var document = conversor.Convert(htmlText);
        
        // using(PdfDocument document=conversor.Convert())
        return htmlText;
    }

    private string PlantillaPorNombre(string nombrePlantilla)
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Plantillas", $"{nombrePlantilla}.html");
        var htmlContent = System.IO.File.ReadAllText(filePath);

        return htmlContent;

    }
}