using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Universidad : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Ranking { get; set; }
    public string? Url { get; set; }
    public string? Observaciones { get; set; }
    public bool EsPrivada { get; set; } = true;
    public int? IdPais { get; set; }
    public int? IdTipoAplicacion { get; set; }
    public int? IdAgencia { get; set; }
    public virtual ICollection<Campus> Campus { get; set; } = new List<Campus>();
    public virtual ICollection<CarreraXUniversidad> CarrerasXuniversidad { get; set; } =
        new List<CarreraXUniversidad>();
    public virtual Agencia? Agencia { get; set; }
    public virtual Pais? Pais { get; set; }
    public virtual Aplicacion? TipoAplicacion { get; set; }
}