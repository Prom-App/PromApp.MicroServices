using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Commands.ActualizarCiudad;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Agencias.Commands.ActualizarAgencia;

public class ActualizarAgenciaCommandHandler : IRequestHandler<ActualizarAgenciaCommand, AgenciaResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActualizarAgenciaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AgenciaResponse> Handle(ActualizarAgenciaCommand request, CancellationToken cancellationToken)
    {
        var agenciaActualizar = await _unitOfWork.Repository<Agencia>().GetByIdAsync(request.Id);

        if (agenciaActualizar is null)
            throw new NotFoundException(nameof(Agencia), request.Id);

        _mapper.Map(request, agenciaActualizar, typeof(ActualizarAgenciaCommand), typeof(Agencia));

        await _unitOfWork.Repository<Agencia>().UpdateAsync(agenciaActualizar);

        return _mapper.Map<AgenciaResponse>(agenciaActualizar);
    }
}