using PromAdmin.Core.Componentes.Ciudades.Dtos;
using PromAdmin.Core.Componentes.Colegios.Dtos;
using PromAdmin.Core.Componentes.Generos.Dtos;

namespace PromAdmin.Core.Componentes.Autenticacion.Usuarios.Dtos;

public class AutenticarResponse
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public CiudadResponse? Ciudad { get; set; }
    public ColegioResponse? Colegio { get; set; }
    public GeneroResponse? Genero { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }
    public ICollection<string>? Roles { get; set; }
}