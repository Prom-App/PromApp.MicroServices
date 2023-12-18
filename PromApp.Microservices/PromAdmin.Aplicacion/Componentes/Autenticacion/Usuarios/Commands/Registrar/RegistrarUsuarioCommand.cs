using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Registrar;

public class RegistrarUsuarioCommand : IRequest<AutenticarResponse>
{
    public string? Email { get; set; }
    public string? Contrasena { get; set; }
    public string? ConfirmaContrasena { get; set; }
    public string Token { get; set; } = string.Empty;
}