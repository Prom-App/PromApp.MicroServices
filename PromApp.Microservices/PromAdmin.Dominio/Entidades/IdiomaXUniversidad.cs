namespace PromAdmin.Dominio.Entidades;

public class IdiomaXUniversidad
{
    public int IdIdioma { get; set; }
    public int IdUniversidad { get; set; }
    public virtual Idioma Idioma { get; set; } = null!;
    public virtual Universidad Universidad { get; set; } = null!;
}