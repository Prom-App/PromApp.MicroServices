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

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Autenticar;

public class AutenticarUsuarioCommandHandler : IRequestHandler<AutenticarUsuarioCommand, AutenticarResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _autenticacionService;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AutenticarUsuarioCommandHandler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IAutenticacionService autenticacionService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _autenticacionService = autenticacionService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AutenticarResponse> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _userManager.FindByEmailAsync(request.Email!);
        if (usuario is null) throw new NotFoundException(nameof(Usuario)!, request.Email!);

        if (!usuario.Activo) throw new Exception($"Usuario está bloqueado");

        var result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Contrasena!, false);

        if (!result.Succeeded) throw new Exception($"Usuario y/o contraseña incorrectos");

        var ciudad = await _unitOfWork.Repository<Ciudad>().GetEntityAsync(x => x.Id == usuario.IdCiudad);
        var colegio = await _unitOfWork.Repository<Colegio>().GetEntityAsync(x => x.Id == usuario.IdColegio);
        var genero = await _unitOfWork.Repository<Dominio.Entidades.Genero>()
            .GetEntityAsync(x => x.Id == usuario.IdGenero);
        
        usuario.Avatar = await _unitOfWork.Repository<Avatar>().GetEntityAsync(x => x.Id == usuario!.IdAvatar);

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
            Token = await _autenticacionService.CrearToken(usuario, roles),
            Roles = roles
        };
        return response;
    }
}