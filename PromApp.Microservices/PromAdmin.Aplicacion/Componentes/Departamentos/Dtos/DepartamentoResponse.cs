using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Departamentos.Dtos;

public class DepartamentoResponse
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public virtual ICollection<Ciudad>? Ciudades { get; set; }
}