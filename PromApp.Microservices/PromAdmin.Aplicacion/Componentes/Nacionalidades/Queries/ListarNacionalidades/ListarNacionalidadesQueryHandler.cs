using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Agencias.Queries.ListarAgencias;
using PromAdmin.Core.Componentes.Nacionalidades.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Nacionalidades.Queries.ListarNacionalidades;

public class ListarNacionalidadesQueryHandler: IRequestHandler<ListarNacionalidadesQuery, IReadOnlyList<NacionalidadResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListarNacionalidadesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<NacionalidadResponse>> Handle(ListarNacionalidadesQuery request,
        CancellationToken cancellationToken)
    {
        var includes = new List<Expression<Func<Nacionalidad, object>>>
        {
            x => x.Pais!
        };

        var nacionalidades = await _unitOfWork.Repository<Nacionalidad>()
            .GetAsync(null, x => x.OrderBy(y => y.Descripcion), includes);

        return _mapper.Map<IReadOnlyList<NacionalidadResponse>>(nacionalidades);
    }
}