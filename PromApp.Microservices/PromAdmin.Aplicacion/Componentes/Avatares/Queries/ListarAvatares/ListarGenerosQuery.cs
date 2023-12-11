using MediatR;
using PromAdmin.Core.Componentes.Avatares.Dtos;

namespace PromAdmin.Core.Componentes.Avatares.Queries.ListarAvatares;

public class ListarAvataresQuery:IRequest<IReadOnlyList<AvatarResponse>>
{
    
}