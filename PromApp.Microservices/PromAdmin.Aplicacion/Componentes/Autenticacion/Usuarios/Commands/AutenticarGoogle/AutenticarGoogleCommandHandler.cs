using AutoMapper;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Core.Modelos.ExternalApis;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.AutenticarGoogle;

public class AutenticarGoogleCommandHandler : IRequestHandler<AutenticarGoogleCommand, AutenticarResponse>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _autenticacionService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly GoogleSettings _googleSettings;

    public AutenticarGoogleCommandHandler(UserManager<Usuario> userManager, IAutenticacionService autenticacionService,
        SignInManager<Usuario> signInManager, IMapper mapper, IUnitOfWork unitOfWork,
        IOptions<GoogleSettings> googleSettings)
    {
        _userManager = userManager;
        _autenticacionService = autenticacionService;
        _unitOfWork = unitOfWork;
        _googleSettings = googleSettings.Value;
    }

    public async Task<AutenticarResponse> Handle(AutenticarGoogleCommand request, CancellationToken cancellationToken)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = new List<string>
            {
                _googleSettings.IdCliente!
            }
        };

        var payload = await GoogleJsonWebSignature.ValidateAsync(request.Credencial, settings);

        var usuario = await _userManager.FindByEmailAsync(payload.Email!);

        if (usuario is null)
        {
            await CrearUsuarioGoogle(payload.Email, request.Token!);
            usuario = await _userManager.FindByEmailAsync(payload.Email!);
        }

        if (!usuario!.Activo) throw new Exception($"Usuario está bloqueado, por favor valide con el administrador");

        var roles = await _userManager.GetRolesAsync(usuario);
        usuario.Avatar = await _unitOfWork.Repository<Avatar>().GetEntityAsync(x => x.Id == usuario!.IdAvatar);
        return new AutenticarResponse
        {
            Id = usuario.Id,
            Email = usuario.Email,
            Token = await _autenticacionService.CrearToken(usuario, roles),
            Roles = roles
        };
    }

    private async Task CrearUsuarioGoogle(string email, string token)
    {
        var usuario = new Usuario
        {
            Email = email,
            UserName = email
        };
        var result = await _userManager.CreateAsync(usuario, "contrasenaparaPROM123*");

        if (!result.Succeeded) throw new Exception("No fue posible registrar el usuario");

        string rolInicial;
        if (email.Contains("@promapp.ai"))
            rolInicial = ListaRoles.Administrador.ToString();
        else
        {
            rolInicial = token.ToUpper() switch
            {
                "FAMILIAR" => ListaRoles.Tutor.ToString(),
                "PREPARADOR" => ListaRoles.Preparador.ToString(),
                "CONSEJERO" => ListaRoles.Consejero.ToString(),
                _ => ListaRoles.Freemium.ToString()
            };
        }

        await _userManager.AddToRoleAsync(usuario, rolInicial);
    }
}