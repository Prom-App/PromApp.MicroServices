using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.ListarCiudades;

public class ListarCiudadesQueryHandler : IRequestHandler<ListarCiudadesQuery, IReadOnlyList<CiudadResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarCiudadesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CiudadResponse>> Handle(ListarCiudadesQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Ciudad, object>>>
        {
            x => x.Colegios,
            x => x.Campus,
            x => x.Usuarios,
            x => x.Departamento,
            x => x.Demografia!
        };

        var products = await _unitOfWork.Repository<Ciudad>()
            .GetAsync(null, x => x.OrderBy(y => y.Nombre), includes);

        return _mapper.Map<IReadOnlyList<CiudadResponse>>(products);
    }
}