using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Commands.CrearAgencia;

public class CrearAgenciaCommand : IRequest<AgenciaResponse>
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public virtual ICollection<Universidad> Universidades { get; set; }
}