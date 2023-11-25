using MediatR;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Queries;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Queries.PaginacionUsuarios;

public class PaginacionUsuariosQuery: PaginacionBaseQuery,IRequest<PaginacionDto<Usuario>>
{
}