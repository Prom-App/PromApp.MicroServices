using MediatR;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.RestablecerContrasenaToken;

public class RestablecerContrasenaTokenCommand : IRequest<string>
{
    public string? Email { get; set; }
    public string? Token { get; set; }
    public string? Contrasena { get; set; }
    public string? ConfirmaContrasena { get; set; }
}