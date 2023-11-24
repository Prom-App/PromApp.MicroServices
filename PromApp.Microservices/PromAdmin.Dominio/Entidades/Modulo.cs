using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Modulo : EntidadBase
{
    public string? NombreModulo { get; set; }
    public bool Activo { get; set; } = true;
    public virtual ICollection<Test>? Pruebas { get; set; }
}