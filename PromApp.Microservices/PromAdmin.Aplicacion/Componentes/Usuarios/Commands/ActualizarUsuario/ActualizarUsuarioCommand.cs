using MediatR;
using Newtonsoft.Json;
using PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

namespace PromAdmin.Core.Componentes.Usuarios.Commands.ActualizarUsuario;

public class ActualizarUsuarioCommand : IRequest<AutenticarResponse>
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public int? IdCiudad { get; set; }
    public int? IdColegio { get; set; }
    public int? IdGenero { get; set; }
    public int? IdAvatar { get; set; }
    public int? IdNacionalidad { get; set; }
    public int? IdNacionalidad2 { get; set; }
    public int? GradoEscolar { get; set; }
}