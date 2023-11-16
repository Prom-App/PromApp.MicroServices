namespace PromAdmin.Dominio.Entidades;

public class CaracteristicaXUniversidad
{
    public int IdCaracteristica { get; set; }
    public int IdCampus { get; set; }
    public virtual Campus Campus { get; set; } = null!;
    public virtual Geografia Geografia { get; set; } = null!;
}