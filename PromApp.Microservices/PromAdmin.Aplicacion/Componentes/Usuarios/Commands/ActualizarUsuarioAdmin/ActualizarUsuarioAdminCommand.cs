using MediatR;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuarioAdmin;

public class ActualizarUsuarioAdminCommand : IRequest<Usuario>
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public int IdCiudad { get; set; }
    public int IdColegio { get; set; }
    public int IdGenero { get; set; }
    public List<string>? Roles { get; set; }
}