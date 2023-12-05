using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Dtos;

public class AgenciaResponse
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public virtual ICollection<Universidad>? Universidades { get; set; }
}