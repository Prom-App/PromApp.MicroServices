using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Departamentos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Departamentos.Queries.ListarDepartamentos;

public class
    ListarDepartamentosQueryHandler : IRequestHandler<ListarDepartamentosQuery, IReadOnlyList<DepartamentoResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarDepartamentosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<DepartamentoResponse>> Handle(ListarDepartamentosQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Departamento, object>>>
        {
            x => x.Ciudades,
        };

        var departamentos = await _unitOfWork.Repository<Departamento>()
            .GetAsync(null, x => x.OrderBy(y => y.Nombre), includes);

        return _mapper.Map<IReadOnlyList<DepartamentoResponse>>(departamentos);
    }
}