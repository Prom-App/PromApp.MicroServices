using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;

public class CrearCiudadCommand : IRequest<CiudadResponse>
{
    public string? Nombre { get; set; }
    public string? Abreviatura { get; set; }
    public int IdDepartamento { get; set; }
    public int? IdDemografia { get; set; }
}