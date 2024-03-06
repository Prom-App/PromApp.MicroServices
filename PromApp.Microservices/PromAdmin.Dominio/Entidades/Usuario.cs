using Microsoft.AspNetCore.Identity;

namespace PromAdmin.Dominio.Entidades;

public class Usuario : IdentityUser
{
    public string? Nombre { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public bool Activo { get; set; } = true;
    public int? IdCiudad { get; set; }
    public int? IdColegio { get; set; }
    public int? IdGenero { get; set; }
    public int? IdNacionalidad { get; set; }
    public int? IdNacionalidad2 { get; set; }
    public int? IdAvatar { get; set; }
    public string? GradoEscolar { get; set; }
    public DateTime FechaCreacion { get; set; }
    public virtual Avatar? Avatar { get; set; }
    public virtual ICollection<Contacto>? Contactos { get; set; }
    public virtual Ciudad? Ciudad { get; set; }
    public virtual Colegio? Colegio { get; set; }
    public virtual Genero? Genero { get; set; }
    public virtual Nacionalidad? Nacionalidad { get; set; }
    public virtual Nacionalidad? Nacionalidad2 { get; set; }
    public virtual ICollection<TestXUsuario>? TestsXUsuario { get; set; }
}