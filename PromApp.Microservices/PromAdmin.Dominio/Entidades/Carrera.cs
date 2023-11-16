using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Carrera : EntidadBase
{
    public string? Nombre { get; set; }
    public int? IdTipoPrograma { get; set; }
    public virtual ICollection<CarreraRelacionada> CarrerasRelacionadas { get; set; } = new List<CarreraRelacionada>();

    public virtual ICollection<CarreraXUniversidad> CarrerasXuniversidad { get; set; } =
        new List<CarreraXUniversidad>();

    public virtual Programa TipoPrograma { get; set; } = null!;
}