using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Actitud: EntidadBase
{
    public string? NombreActitud { get; set; }
    public virtual ICollection<ActitudXCarrera>? ActitudesXCarrera { get; set; } 
}