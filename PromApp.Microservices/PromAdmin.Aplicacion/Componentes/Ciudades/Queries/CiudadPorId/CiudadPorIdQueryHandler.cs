using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.CiudadPorId;

public class CiudadPorIdQueryHandler : IRequestHandler<CiudadPorIdQuery, CiudadResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CiudadPorIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CiudadResponse> Handle(CiudadPorIdQuery request, CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Ciudad, object>>>
        {
            x => x.Colegios,
            x => x.Campus,
            x => x.Usuarios,
            x => x.Departamento,
            x => x.Demografia!
        };

        var product = await _unitOfWork.Repository<Ciudad>().GetEntityAsync(x => x.Id == request.IdCiudad, includes);

        return _mapper.Map<CiudadResponse>(product);
    }
}