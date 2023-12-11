using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Paises.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Paises.Queries.PaisPorId;

public class PaisPorIdQueryHandler: IRequestHandler<PaisPorIdQuery, PaisResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaisPorIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaisResponse> Handle(PaisPorIdQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Pais, object>>>
        {
            x => x.Departamentos
        };

        var pais = await _unitOfWork.Repository<Pais>().GetEntityAsync(x => x.Id == request.IdPais, includes);

        return _mapper.Map<PaisResponse>(pais);
    }
}