using MediatR;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;

public class ActualizarUsuarioCommand : IRequest<AutenticarResponse>
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public int IdCiudad { get; set; }
    public int IdColegio { get; set; }
    public int IdGenero { get; set; }
}