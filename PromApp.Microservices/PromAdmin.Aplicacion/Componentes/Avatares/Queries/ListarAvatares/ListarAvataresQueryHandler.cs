using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Avatares.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Avatares.Queries.ListarAvatares;

public class ListarAvataresQueryHandler : IRequestHandler<ListarAvataresQuery, IReadOnlyList<AvatarResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarAvataresQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<AvatarResponse>> Handle(ListarAvataresQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Avatar, object>>>
        {
        };

        var avatares = await _unitOfWork.Repository<Avatar>()
            .GetAsync(null, x => x.OrderBy(y => y.Nombre), includes);

        return _mapper.Map<IReadOnlyList<AvatarResponse>>(avatares);
    }
}