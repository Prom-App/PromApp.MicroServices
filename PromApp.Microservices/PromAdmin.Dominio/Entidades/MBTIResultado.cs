using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class MBTIResultado:EntidadBase
{
    public string IdUsuario { get; set; }
    public int IdTestXUsuario { get; set; }
    public string? Resultado { get; set; }
    public int Extroversion { get; set; }
    public int Introversion { get; set; }
    public int Sensing { get; set; }
    public int Intuition { get; set; }
    public int Thinking { get; set; }
    public int Feeling { get; set; }
    public int Judging { get; set; }
    public int Perceiving { get; set; }
}