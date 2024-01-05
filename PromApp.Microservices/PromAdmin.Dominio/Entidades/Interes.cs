namespace PromAdmin.Dominio.Entidades;

public class Interes: EntidadBase
{
    public string? NombreInteres { get; set; }
    public virtual ICollection<ActitudXCarrera>? ActitudesXCarrera { get; set; } 
}