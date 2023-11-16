namespace PromAdmin.Dominio.Entidades;

public class CarreraXUniversidad
{
    public int? IdUniversidad { get; set; }
    public int? IdCarrera { get; set; }
    public string? Url { get; set; }
    public decimal? Costo { get; set; }
    public virtual Carrera? Carrera { get; set; }
    public virtual Universidad? Universidad { get; set; }
}