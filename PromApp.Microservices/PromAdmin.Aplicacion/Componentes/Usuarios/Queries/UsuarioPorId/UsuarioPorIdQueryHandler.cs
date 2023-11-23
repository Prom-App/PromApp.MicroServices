using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Queries.UsuarioPorId;

public class UsuarioPorIdQueryHandler : IRequestHandler<UsuarioPorIdQuery, AutenticarResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioPorIdQueryHandler(UserManager<Usuario> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<AutenticarResponse> Handle(UsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByIdAsync(request.IdUsuario!);

        if (usuario is null)
            throw new BadRequestException("Usuario no existe");
        var ciudad = await _unitOfWork.Repository<Ciudad>().GetEntityAsync(x => x.Id == usuario.IdCiudad);
        var colegio = await _unitOfWork.Repository<Colegio>().GetEntityAsync(x => x.Id == usuario.IdColegio);
        var genero = await _unitOfWork.Repository<Dominio.Entidades.Genero>()
            .GetEntityAsync(x => x.Id == usuario.IdGenero);

        var roles = await _userManager.GetRolesAsync(usuario);

        var response = new AutenticarResponse
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            FechaNacimiento = usuario.FechaNacimiento,
            Telefono = usuario.Telefono,
            Email = usuario.Email,
            Direccion = usuario.Direccion,
            Ciudad = _mapper.Map<CiudadResponse>(ciudad),
            Colegio = _mapper.Map<ColegioResponse>(colegio),
            Genero = _mapper.Map<GeneroResponse>(genero),
            Roles = roles
        };
        return response;
    }
}