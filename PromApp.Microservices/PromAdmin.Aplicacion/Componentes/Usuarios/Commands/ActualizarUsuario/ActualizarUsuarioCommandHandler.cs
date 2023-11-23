using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;

public class ActualizarUsuarioCommandHandler : IRequestHandler<ActualizarUsuarioCommand, AutenticarResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActualizarUsuarioCommandHandler(UserManager<Usuario> userManager, IAutenticacionService authService,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userManager = userManager;
        _authService = authService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AutenticarResponse> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioActualizar = await _userManager.FindByEmailAsync(await _authService.ObtenerSesion());

        if (usuarioActualizar is null)
            throw new BadRequestException("Usuario no existe");

        usuarioActualizar.Nombre = request.Nombre;
        usuarioActualizar.Telefono = request.Telefono;
        usuarioActualizar.Direccion = request.Direccion;
        usuarioActualizar.FechaNacimiento = request.FechaNacimiento;
        usuarioActualizar.IdCiudad = request.IdCiudad;
        usuarioActualizar.IdColegio = request.IdColegio;
        usuarioActualizar.IdGenero = request.IdGenero;

        var result = await _userManager.UpdateAsync(usuarioActualizar);

        if (!result.Succeeded)
            throw new Exception("Ha fallado la actualización del usuario");

        var usuario = await _userManager.FindByEmailAsync(usuarioActualizar.Email!);
        var roles = await _userManager.GetRolesAsync(usuario!);
        var ciudad = await _unitOfWork.Repository<Ciudad>().GetEntityAsync(x => x.Id == usuario!.IdCiudad);
        var colegio = await _unitOfWork.Repository<Colegio>().GetEntityAsync(x => x.Id == usuario!.IdColegio);
        var genero = await _unitOfWork.Repository<Genero>().GetEntityAsync(x => x.Id == usuario!.IdGenero);

        return new AutenticarResponse
        {
            Id = usuario!.Id,
            Nombre = usuario.Nombre,
            Telefono = usuario.Telefono,
            Direccion = usuario.Direccion,
            Email = usuario.Email,
            Ciudad = _mapper.Map<CiudadResponse>(ciudad),
            Colegio = _mapper.Map<ColegioResponse>(colegio),
            Genero = _mapper.Map<GeneroResponse>(genero),
            Roles = roles,
            Token = await _authService.CrearToken(usuario, roles)
        };
    }
}