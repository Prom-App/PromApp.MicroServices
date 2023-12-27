using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Tests.Dtos;

public class TestResponse
{
    public int Id { get; set; }
    public string? NombreTest { get; set; }
    public string? Descripcion { get; set; }
    public string? Observacion { get; set; }
    public virtual ICollection<Seccion>? Secciones { get; set; }
    public virtual ICollection<Pregunta>? Preguntas { get; set; }
}