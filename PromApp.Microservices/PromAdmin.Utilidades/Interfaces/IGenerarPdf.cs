namespace PromAdmin.Utilidades.Interfaces;

public interface IGenerarPdf
{
    Task<byte[]> ConvertirAPdf(string nombrePlantilla, string data);
}