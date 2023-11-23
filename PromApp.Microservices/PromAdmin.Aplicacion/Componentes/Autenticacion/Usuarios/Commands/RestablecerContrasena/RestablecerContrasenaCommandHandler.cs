using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.RestablecerContrasena;

public class RestablecerContrasenaCommandHandler : IRequestHandler<RestablecerContrasenaCommand, string>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly IAutenticacionService _autenticacionService;

    public async Task<string> Handle(RestablecerContrasenaCommand request, CancellationToken cancellationToken)
    {
        var usuarioActualizar = await _userManager.FindByNameAsync(await _autenticacionService.ObtenerSesion());

        if (usuarioActualizar is null)
            throw new BadRequestException("Usuario no existe");

        var validarContrasena = _userManager.PasswordHasher.VerifyHashedPassword(usuarioActualizar,
            usuarioActualizar.PasswordHash!, request.ContrasenaAnterior!);

        if (validarContrasena != PasswordVerificationResult.Success)
            throw new Exception("La contraseña anterior es incorrecta");

        var contrasenaNueva = _userManager.PasswordHasher.HashPassword(usuarioActualizar, request.ContrasenaNueva!);
        usuarioActualizar.PasswordHash = contrasenaNueva;

        var result = await _userManager.UpdateAsync(usuarioActualizar);

        if (!result.Succeeded)
            throw new Exception("Ocurrió un error al cambiar la contraseña");

        return "Contraseña actualizada";
    }
}