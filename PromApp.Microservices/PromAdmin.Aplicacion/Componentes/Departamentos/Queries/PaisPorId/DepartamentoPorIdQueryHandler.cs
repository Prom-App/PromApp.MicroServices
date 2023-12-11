using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Departamentos.Dtos;
using PromAdmin.Core.Componentes.Departamentos.Queries.PaisPorId;
using PromAdmin.Core.Componentes.Paises.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Paises.Queries.PaisPorId;

public class DepartamentoPorIdQueryHandler : IRequestHandler<DepartamentoPorIdQuery, DepartamentoResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartamentoPorIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DepartamentoResponse> Handle(DepartamentoPorIdQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Departamento, object>>>
        {
            x => x.Ciudades
        };

        var departamento = await _unitOfWork.Repository<Departamento>()
            .GetEntityAsync(x => x.Id == request.IdDepartamento, includes);

        return _mapper.Map<DepartamentoResponse>(departamento);
    }
}