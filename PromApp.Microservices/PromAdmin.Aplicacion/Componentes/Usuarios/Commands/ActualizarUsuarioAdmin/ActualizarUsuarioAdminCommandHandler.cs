using MediatR;
using Microsoft.AspNetCore.Identity;
using PromAdmin.Core.Exceptions;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioAdmin;

public class ActualizarUsuarioAdminCommandHandler : IRequestHandler<ActualizarUsuarioAdminCommand, Usuario>
{
    private readonly UserManager<Usuario> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ActualizarUsuarioAdminCommandHandler(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Usuario> Handle(ActualizarUsuarioAdminCommand request, CancellationToken cancellationToken)
    {
        var usuarioActualizar = await _userManager.FindByIdAsync(request.Id!);

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

        request.Roles!.ForEach(x =>
        {
            var rol = _roleManager.FindByNameAsync(x!).Result;
            if (rol is not null)
                _userManager.AddToRoleAsync(usuarioActualizar, rol.Name!);
        });

        return usuarioActualizar;
    }
}