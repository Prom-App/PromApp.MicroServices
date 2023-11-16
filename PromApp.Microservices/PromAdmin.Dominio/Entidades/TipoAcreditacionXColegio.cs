namespace PromAdmin.Dominio.Entidades;

public class TipoAcreditacionXColegio
{
    public int IdAcreditacion { get; set; }
    public int IdColegio { get; set; }
    public virtual Acreditacion TipoAcreditacion { get; set; } = null!;
    public virtual Colegio Colegio { get; set; } = null!;
}