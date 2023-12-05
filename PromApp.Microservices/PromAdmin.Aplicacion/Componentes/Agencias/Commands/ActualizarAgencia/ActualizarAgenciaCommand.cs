using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Commands.ActualizarAgencia;

public class ActualizarAgenciaCommand : IRequest<AgenciaResponse>
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public virtual ICollection<Universidad> Universidades { get; set; }
}