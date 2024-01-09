using PromAdmin.Dominio.Compartido;

namespace PromAdmin.Dominio.Entidades;

public class Personalidad : EntidadBase
{
    public string? Codigo { get; set; }
    public string? Definicion { get; set; }
    public string? Descripcion { get; set; }
    public string? Recomendadas { get; set; }
    public string? Futuro { get; set; }
    public string? Evitar { get; set; }
    public virtual ICollection<CualidadXPersonalidad>? CualidadesXPersonalidad { get; set; }
    public virtual ICollection<CarreraRecomendadaXPersonalidad>? CarrerasRecomendadas { get; set; }
    public virtual ICollection<CarreraFuturoXPersonalidad>? CarrerasFuturo { get; set; }
    public virtual ICollection<CarreraEvitarXPersonalidad>? CarrerasEvitar { get; set; }
}