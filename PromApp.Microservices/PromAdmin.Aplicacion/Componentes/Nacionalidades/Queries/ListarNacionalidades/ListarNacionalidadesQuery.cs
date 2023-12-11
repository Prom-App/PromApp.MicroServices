using MediatR;
using PromAdmin.Core.Componentes.Nacionalidades.Dtos;

namespace PromAdmin.Core.Componentes.Nacionalidades.Queries.ListarNacionalidades;

public class ListarNacionalidadesQuery : IRequest<IReadOnlyList<NacionalidadResponse>>
{
    
}