using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Campus : EntidadBase
{
    public string? Nombre { get; set; }
    public string? LaFiesta { get; set; }
    public string? Url { get; set; }
    public int? IdUniversidad { get; set; }
    public int? IdCiudad { get; set; }
    public virtual Ciudad? Ciudad { get; set; }
    public virtual Universidad? Universidad { get; set; }
}