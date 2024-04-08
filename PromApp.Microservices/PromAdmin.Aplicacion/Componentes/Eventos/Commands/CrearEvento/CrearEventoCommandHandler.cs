using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using PromAdmin.Core.Componentes.Eventos.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Almacenamiento;
using PromAdmin.Core.Modelos.Options;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Eventos.Commands.CrearEvento;

public class CrearEventoCommandHandler : IRequestHandler<CrearEventoCommand, EventoResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAzureStorageService _azureStorageService;
    private readonly AzureSettings _azureSettings;


    public CrearEventoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAzureStorageService azureStorageService,
        IOptions<AzureSettings> azureSettings)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _azureStorageService = azureStorageService;
        _azureSettings = azureSettings.Value;
    }

    public async Task<EventoResponse> Handle(CrearEventoCommand request, CancellationToken cancellationToken)
    {
        var urlImage = string.Empty;
        if (request.Imagen != null)
        {
            urlImage = await _azureStorageService.SaveFile(_azureSettings.ContainerMediaName!, "Images/Events",
                request.Imagen);
        }

        var evento = _mapper.Map<Evento>(request);
        evento.UrlImagen = urlImage;

        await _unitOfWork.Repository<Evento>().AddAsync(evento);

        return _mapper.Map<EventoResponse>(evento);
    }
}