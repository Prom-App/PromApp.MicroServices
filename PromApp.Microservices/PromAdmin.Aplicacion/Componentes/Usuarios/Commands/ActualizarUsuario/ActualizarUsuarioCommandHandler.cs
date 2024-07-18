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

        if (!string.IsNullOrEmpty(request.Nombre!))
            usuarioActualizar.Nombre = request.Nombre;

        if (!string.IsNullOrEmpty(request.Telefono))
            usuarioActualizar.Telefono = request.Telefono;

        if (!string.IsNullOrEmpty(request.Direccion))
            usuarioActualizar.Direccion = request.Direccion;
        
        if (!string.IsNullOrEmpty(request.GradoEscolar))
            usuarioActualizar.GradoEscolar = request.GradoEscolar;

        if (!string.IsNullOrEmpty(request.CondicionEspecial))
            usuarioActualizar.CondicionEspecial = request.CondicionEspecial;
        
        if (request.FechaNacimiento != null)
            usuarioActualizar.FechaNacimiento = request.FechaNacimiento;

        if (request.IdCiudad is > 0)
            usuarioActualizar.IdCiudad = request.IdCiudad;

        if (request.IdColegio is > 0)
            usuarioActualizar.IdColegio = request.IdColegio;

        if (request.IdGenero is > 0)
            usuarioActualizar.IdGenero = request.IdGenero;

        if (request.IdAvatar is > 0)
            usuarioActualizar.IdAvatar = request.IdAvatar;

        if (request.IdNacionalidad is > 0)
            usuarioActualizar.IdNacionalidad = request.IdNacionalidad;

        if (request.IdNacionalidad2 is > 0)
            usuarioActualizar.IdNacionalidad2 = request.IdNacionalidad2;

        var result = await _userManager.UpdateAsync(usuarioActualizar);

        if (!result.Succeeded)
            throw new Exception("Ha fallado la actualización del usuario");

        var usuario = usuarioActualizar;
        var roles = await _userManager.GetRolesAsync(usuario!);
        var ciudad = await _unitOfWork.Repository<Ciudad>().GetEntityAsync(x => x.Id == usuario!.IdCiudad);
        var colegio = await _unitOfWork.Repository<Colegio>().GetEntityAsync(x => x.Id == usuario!.IdColegio);
        var genero = await _unitOfWork.Repository<Genero>().GetEntityAsync(x => x.Id == usuario!.IdGenero);
        usuario.Avatar = await _unitOfWork.Repository<Avatar>().GetEntityAsync(x => x.Id == usuario!.IdAvatar);

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