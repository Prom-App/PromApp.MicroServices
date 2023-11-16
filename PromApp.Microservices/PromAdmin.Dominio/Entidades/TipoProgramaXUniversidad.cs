namespace PromAdmin.Dominio.Entidades;

public class TipoProgramaXUniversidad
{
    public int IdTipoPrograma { get; set; }
    public int IdUniversidad { get; set; }
    public virtual Programa TipoPrograma { get; set; } = null!;
    public virtual Universidad Universidad { get; set; } = null!;
}