using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Commands.Autenticar;

public class AutenticarUsuarioCommand : IRequest<AutenticarResponse>
{
    public string? Email { get; set; }
    public string? Contrasena { get; set; }
    //public string? TipoAutenticacion { get; set; }
}