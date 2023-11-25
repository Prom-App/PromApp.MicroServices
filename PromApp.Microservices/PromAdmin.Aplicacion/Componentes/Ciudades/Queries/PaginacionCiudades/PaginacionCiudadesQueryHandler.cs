using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Specifications.Ciudades;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Queries.PaginacionCiudades;

public class PaginacionCiudadesQueryHandler : IRequestHandler<PaginacionCiudadesQuery, PaginacionDto<CiudadResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaginacionCiudadesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginacionDto<CiudadResponse>> Handle(PaginacionCiudadesQuery request,
        CancellationToken cancellationToken)
    {
        var ciudadSpecificationParams = new CiudadSpecificationParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };

        var spec = new CiudadSpecification(ciudadSpecificationParams);
        var products = await _unitOfWork.Repository<Ciudad>().GetAllWithSpec(spec);

        var specCount = new CiudadForCountingSpecification(ciudadSpecificationParams);
        var totalProducts = await _unitOfWork.Repository<Ciudad>().CountAsync(specCount);

        var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);

        var data = _mapper.Map<IReadOnlyList<CiudadResponse>>(products);
        var elementsByPage = data.Count;

        var pagination = new PaginacionDto<CiudadResponse>()
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