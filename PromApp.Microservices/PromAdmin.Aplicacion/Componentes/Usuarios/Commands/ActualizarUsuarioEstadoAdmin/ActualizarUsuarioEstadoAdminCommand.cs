using MediatR;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioEstadoAdmin;

public class ActualizarUsuarioEstadoAdminCommand : IRequest<Usuario>
{
    public string? Id { get; set; }
}