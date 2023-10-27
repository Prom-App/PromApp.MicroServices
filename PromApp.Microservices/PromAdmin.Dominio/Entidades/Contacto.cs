using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Contacto : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public int IdParentesco { get; set; }
    public int IdUsuario { get; set; }
    public int IdUsuarioContacto { get; set; }
}