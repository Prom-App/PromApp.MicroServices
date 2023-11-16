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
    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
    public virtual Ciudad? Ciudad { get; set; }
    public virtual Colegio? Colegio { get; set; }
    public virtual Genero? Genero { get; set; }
}