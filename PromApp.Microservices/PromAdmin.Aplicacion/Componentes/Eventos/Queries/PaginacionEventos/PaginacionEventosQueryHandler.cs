using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Compartidos.Dtos;
using PromAdmin.Core.Componentes.Eventos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Specifications.Eventos;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Eventos.Queries.PaginacionEventos;

public class PaginacionEventosQueryHandler : IRequestHandler<PaginacionEventosQuery, PaginacionDto<EventoResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaginacionEventosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaginacionDto<EventoResponse>> Handle(PaginacionEventosQuery request, CancellationToken cancellationToken)
    {
        var eventSpecParams = new EventSpecificationParams()
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort
        };

        var eventSpec = new EventSpecification(eventSpecParams);
        var events = await _unitOfWork.Repository<Evento>().GetAllWithSpec(eventSpec);

        var specCount = new EventForCountingSpecification(eventSpecParams);
        var totalEvents = await _unitOfWork.Repository<Evento>().CountAsync(specCount);

        var rounded = Math.Ceiling(Convert.ToDecimal(totalEvents) / Convert.ToDecimal(request.PageSize));
        var totalPages = Convert.ToInt32(rounded);

        var pagination = new PaginacionDto<EventoResponse>
        {
            Count = totalEvents,
            Data = _mapper.Map<IReadOnlyList<EventoResponse>>(events),
            PageCount = totalPages,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            ResultByPage = events.Count
        };

        return pagination;
    }
}