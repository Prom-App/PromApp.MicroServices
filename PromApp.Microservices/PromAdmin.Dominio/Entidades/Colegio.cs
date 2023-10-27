using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Colegio : EntidadBase
{
    public string? Nombre { get; set; }
    public string? Url { get; set; }
    public bool Privado { get; set; } = true;
    public int IdCiudad { get; set; }
}