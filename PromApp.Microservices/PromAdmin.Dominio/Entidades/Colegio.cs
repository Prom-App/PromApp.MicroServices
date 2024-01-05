using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Colegio : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public bool EsPrivado { get; set; } = true;
    public int? IdCiudad { get; set; }
    public int? IdPais { get; set; }
    public virtual Ciudad? Ciudad { get; set; }
    public virtual Pais? Pais { get; set; }
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}