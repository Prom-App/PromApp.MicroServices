namespace PromAdmin.Dominio.Entidades;

public class HabilidadXCarrera
{
    public int IdCarrera { get; set; }
    public int IdHabilidad { get; set; }
    public virtual Carrera? Carrera { get; set; }
    public virtual Habilidad? Habilidad { get; set; }
}