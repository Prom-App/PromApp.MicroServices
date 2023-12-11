using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Paises.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Paises.Queries.ListarPaises;

public class ListarPaisesQueryHandler : IRequestHandler<ListarPaisesQuery, IReadOnlyList<PaisResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarPaisesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<PaisResponse>> Handle(ListarPaisesQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Pais, object>>>();

        var paises = await _unitOfWork.Repository<Pais>()
            .GetAsync(null, x => x.OrderBy(y => y.Nombre), includes);

        return _mapper.Map<IReadOnlyList<PaisResponse>>(paises);
    }
}