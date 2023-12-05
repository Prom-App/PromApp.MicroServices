using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Specifications.Agencias;
using PromAdmin.Core.Specifications.Ciudades;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Queries.PaginacionAgencias;

public class PaginacionAgenciasQueryHandler : IRequestHandler<PaginacionAgenciasQuery, PaginacionDto<AgenciaResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaginacionAgenciasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginacionDto<AgenciaResponse>> Handle(PaginacionAgenciasQuery request,
        CancellationToken cancellationToken)
    {
        var agenciaSpecificationParams = new AgenciaSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };

        var spec = new AgenciaSpecification(agenciaSpecificationParams);
        var agencias = await _unitOfWork.Repository<Agencia>().GetAllWithSpec(spec);

        var specCount = new AgenciaForCountingSpecification(agenciaSpecificationParams);
        var totalProducts = await _unitOfWork.Repository<Agencia>().CountAsync(specCount);

        var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);

        var data = _mapper.Map<IReadOnlyList<AgenciaResponse>>(agencias);
        var elementsByPage = data.Count;

        var pagination = new PaginacionDto<AgenciaResponse>()
        {
            Count = totalProducts,
            Data = data,
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = elementsByPage
        };

        return pagination;
    }
}