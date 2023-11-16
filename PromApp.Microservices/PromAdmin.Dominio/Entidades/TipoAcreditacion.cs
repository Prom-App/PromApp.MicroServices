using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Acreditacion : EntidadBase
{
    public string? TipoAcreditacion { get; set; }
    public bool Internacional { get; set; } = false;
}