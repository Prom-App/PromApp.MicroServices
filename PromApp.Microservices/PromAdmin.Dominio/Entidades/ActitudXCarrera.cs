namespace PromAdmin.Dominio.Entidades;

public class ActitudXCarrera
{
    public int IdCarrera { get; set; }
    public int IdActitud { get; set; }
    public virtual Carrera? Carrera { get; set; }
    public virtual Actitud? Actitud { get; set; }
}