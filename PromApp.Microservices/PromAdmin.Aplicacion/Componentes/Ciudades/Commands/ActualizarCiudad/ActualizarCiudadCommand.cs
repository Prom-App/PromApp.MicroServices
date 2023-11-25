using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;

public class ActualizarCiudadCommand : IRequest<CiudadResponse>
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }
    public int IdDepartamento { get; set; }
    public int? IdDemografia { get; set; }
}