using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Seccion : EntidadBase
{
    public string? Codigo { get; set; }
    public string? NombreSeccion { get; set; }
    public string? Descripcion { get; set; }
    public bool Activo { get; set; } = true;
    public int? IdTest { get; set; }
    public virtual Test? Test { get; set; }
    public virtual ICollection<Pregunta>? Preguntas { get; set; }
}