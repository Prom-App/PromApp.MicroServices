using MediatR;
using PromAdmin.Core.Componentes.Nacionalidades.Dtos;

namespace PromAdmin.Core.Componentes.Nacionalidades.Commands.CrearNacionalidad;

public class CrearNacionalidadCommand : IRequest<NacionalidadResponse>
{
    public string? Nacionalidad { get; set; }
    public int IdPais { get; set; }
}