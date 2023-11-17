using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Contacto : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public int IdParentesco { get; set; }
    public string IdUsuario { get; set; }
    public string IdUsuarioContacto { get; set; }
    public virtual Parentesco Parentesco { get; set; } = null!;
    public virtual Usuario? Usuario { get; set; }
    public virtual Usuario? UsuarioContacto { get; set; } = null!;
}