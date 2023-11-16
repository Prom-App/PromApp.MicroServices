using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Ciudad : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Iso2 { get; set; }
    public int IdDepartamento { get; set; }
    public int? IdDemografia { get; set; }
    public virtual ICollection<Campus> Campus { get; set; } = new List<Campus>();
    public virtual ICollection<Colegio> Colegios { get; set; } = new List<Colegio>();
    public virtual Demografia? Demografia { get; set; }
    public virtual Departamento Departamento { get; set; } = null!;
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}