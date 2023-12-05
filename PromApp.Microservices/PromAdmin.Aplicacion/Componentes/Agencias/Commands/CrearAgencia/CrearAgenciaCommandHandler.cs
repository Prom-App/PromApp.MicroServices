using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Commands.CrearAgencia;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Ciudades.Commands.CrearCiudad;

public class CrearAgenciaCommandHandler : IRequestHandler<CrearAgenciaCommand, AgenciaResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CrearAgenciaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AgenciaResponse> Handle(CrearAgenciaCommand request, CancellationToken cancellationToken)
    {
        var agencia = _mapper.Map<Agencia>(request);

        await _unitOfWork.Repository<Agencia>().AddAsync(agencia);

        return _mapper.Map<AgenciaResponse>(agencia);
    }
}