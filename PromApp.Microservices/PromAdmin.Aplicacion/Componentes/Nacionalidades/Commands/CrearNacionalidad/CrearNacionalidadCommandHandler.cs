using AutoMapper;
using MediatR;
using PromAdmin.Core.Componentes.Agencias.Commands.CrearAgencia;
using PromAdmin.Core.Componentes.Agencias.Dtos;
using PromAdmin.Core.Componentes.Nacionalidades.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Nacionalidades.Commands.CrearNacionalidad;

public class CrearNacionalidadCommandHandler: IRequestHandler<CrearNacionalidadCommand, NacionalidadResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CrearNacionalidadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NacionalidadResponse> Handle(CrearNacionalidadCommand request, CancellationToken cancellationToken)
    {
        var nacionalidad = (await _unitOfWork.Repository<Nacionalidad>()
            .GetAsync(x => x.Descripcion == request.Nacionalidad || x.IdPais == request.IdPais)).FirstOrDefault();

        if (nacionalidad is not null)
            throw new BadRequestException("Nacionalidad o país referenciado ya existen");
        
        nacionalidad = _mapper.Map<Nacionalidad>(request);

        await _unitOfWork.Repository<Nacionalidad>().AddAsync(nacionalidad);

        nacionalidad.Pais = await _unitOfWork.Repository<Pais>().GetByIdAsync(request.IdPais);

        return _mapper.Map<NacionalidadResponse>(nacionalidad);
    }
}