using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class TestXUsuario:EntidadBase
{
    public string? IdUsuario { get; set; }
    public int IdTest { get; set; }
    public bool Finalizado { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Test Test { get; set; } = null!;
    public virtual ICollection<RespuestaXTest>? RespuestasTest { get; set; }
}