using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioEstadoAdmin;

public class ActualizarUsuarioEstadoAdminCommandHandler : IRequestHandler<ActualizarUsuarioEstadoAdminCommand, Usuario>
{
    private readonly UserManager<Usuario> _userManager;

    public ActualizarUsuarioEstadoAdminCommandHandler(UserManager<Usuario> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Usuario> Handle(ActualizarUsuarioEstadoAdminCommand request, CancellationToken cancellationToken)
    {
        var usuarioActualizar = await _userManager.FindByIdAsync(request.Id!);

        if (usuarioActualizar is null)
            throw new BadRequestException("Usuario no existe");

        usuarioActualizar.Activo = !usuarioActualizar.Activo;
        var result = await _userManager.UpdateAsync(usuarioActualizar);

        if (!result.Succeeded)
            throw new Exception("No fue posible modificar el estado del usuario");

        return usuarioActualizar;
    }
}