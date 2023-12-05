using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Queries.AgenciaPorId;

public class AgenciadPorIdQueryHandler : IRequestHandler<AgenciaPorIdQuery, AgenciaResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AgenciadPorIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AgenciaResponse> Handle(AgenciaPorIdQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Agencia, object>>>
        {
            x => x.Universidades
        };

        var agencia = await _unitOfWork.Repository<Agencia>().GetEntityAsync(x => x.Id == request.IdAgencia, includes);

        return _mapper.Map<AgenciaResponse>(agencia);
    }
}