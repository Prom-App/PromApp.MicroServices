using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;

public class ActualizarCiudadCommandHandler : IRequestHandler<ActualizarCiudadCommand, CiudadResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActualizarCiudadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CiudadResponse> Handle(ActualizarCiudadCommand request, CancellationToken cancellationToken)
    {
        var ciudadActualizar = await _unitOfWork.Repository<Ciudad>().GetByIdAsync(request.Id);

        if (ciudadActualizar is null)
            throw new NotFoundException(nameof(Ciudad), request.Id);

        _mapper.Map(request, ciudadActualizar, typeof(ActualizarCiudadCommand), typeof(Ciudad));

        await _unitOfWork.Repository<Ciudad>().UpdateAsync(ciudadActualizar);

        return _mapper.Map<CiudadResponse>(ciudadActualizar);
    }
}