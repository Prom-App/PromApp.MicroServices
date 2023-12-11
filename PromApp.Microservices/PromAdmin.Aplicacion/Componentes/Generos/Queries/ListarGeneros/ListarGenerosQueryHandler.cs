using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Generos.Queries.ListarGeneros;

public class ListarGenerosQueryHandler: IRequestHandler<ListarGenerosQuery, IReadOnlyList<GeneroResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarGenerosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GeneroResponse>> Handle(ListarGenerosQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Genero, object>>>
        {
        };

        var generos = await _unitOfWork.Repository<Genero>()
            .GetAsync(null, x => x.OrderBy(y => y.TipoGenero), includes);

        return _mapper.Map<IReadOnlyList<GeneroResponse>>(generos);
    }
}