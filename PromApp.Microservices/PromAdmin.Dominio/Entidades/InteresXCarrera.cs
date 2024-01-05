namespace PromAdmin.Dominio.Entidades;

public class InteresXCarrera
{
    public int IdCarrera { get; set; }
    public int IdInteres { get; set; }
    public virtual Carrera? Carrera { get; set; }
    public virtual Interes? Interes { get; set; }
}