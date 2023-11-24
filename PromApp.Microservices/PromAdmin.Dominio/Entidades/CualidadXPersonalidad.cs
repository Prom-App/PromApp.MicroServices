namespace PromAdmin.Dominio.Entidades;

public class CualidadXPersonalidad
{
    public int IdPersonalidad { get; set; }
    public int IdCualidad { get; set; }
    public virtual Personalidad? Personalidad { get; set; }
    public virtual Cualidad? Cualidad { get; set; }
}