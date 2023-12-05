using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Queries.ListarAgencias;

public class ListarAgenciasQueryHandler : IRequestHandler<ListarAgenciasQuery, IReadOnlyList<AgenciaResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarAgenciasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<AgenciaResponse>> Handle(ListarAgenciasQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Agencia, object>>>
        {
            x => x.Universidades
        };

        var agencias = await _unitOfWork.Repository<Agencia>()
            .GetAsync(null, x => x.OrderBy(y => y.Nombre), includes);

        return _mapper.Map<IReadOnlyList<AgenciaResponse>>(agencias);
    }
}