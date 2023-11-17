namespace PromAdmin.Core.Componentes.Colegios.Dtos;

public class ColegioResponse
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public bool EsPrivado { get; set; } = true;
}