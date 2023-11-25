using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Queries;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.PaginacionCiudades;

public class PaginacionCiudadesQuery: PaginacionBaseQuery, IRequest<PaginacionDto<CiudadResponse>>
{
    
}