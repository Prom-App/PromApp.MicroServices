using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.RestablecerContrasenaToken;

public class RestablecerContrasenaTokenCommandHandler : IRequestHandler<RestablecerContrasenaTokenCommand, string>
{
    private readonly UserManager<Usuario> _userManager;

    public RestablecerContrasenaTokenCommandHandler(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(RestablecerContrasenaTokenCommand request, CancellationToken cancellationToken)
    {
        if (request.Contrasena != request.ConfirmaContrasena)
            throw new BadRequestException("Las contraseñas no coinciden");

        var usuarioActualizar = await _userManager.FindByEmailAsync(request.Email!);
        if (usuarioActualizar is null)
            throw new BadRequestException("Usuario no registrado");

        var token = Convert.FromBase64String(request.Token!);
        var tokenResult = Encoding.UTF8.GetString(token);

        var result = await _userManager.ResetPasswordAsync(usuarioActualizar, tokenResult, request.Contrasena!);

        if (!result.Succeeded)
            throw new Exception("Ha fallado restablecer la contraseña");

        return "Contraseña actualizada";
    }
}