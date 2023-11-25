using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;

public class CrearCiudadCommandHandler : IRequestHandler<CrearCiudadCommand, CiudadResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CrearCiudadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CiudadResponse> Handle(CrearCiudadCommand request, CancellationToken cancellationToken)
    {
        var ciudad = _mapper.Map<Ciudad>(request);

        await _unitOfWork.Repository<Ciudad>().AddAsync(ciudad);

        return _mapper.Map<CiudadResponse>(ciudad);
    }
}