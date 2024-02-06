using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Interes: EntidadBase
{
    public string? NombreInteres { get; set; }
    public virtual ICollection<InteresXCarrera>? InteresesXCarrera { get; set; } 
}