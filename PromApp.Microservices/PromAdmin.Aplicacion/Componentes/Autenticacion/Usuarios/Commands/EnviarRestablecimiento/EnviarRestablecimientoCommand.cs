using MediatR;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.EnviarRestablecimiento;

public class EnviarRestablecimientoCommand : IRequest<string>
{
    public string? Email { get; set; }
}