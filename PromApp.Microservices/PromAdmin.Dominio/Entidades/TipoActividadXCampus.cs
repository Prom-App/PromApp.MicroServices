namespace PromAdmin.Dominio.Entidades;

public class TipoActividadXCampus
{
    public int IdTipoActividad { get; set; }
    public int IdCampus { get; set; }
    public virtual Campus Campus { get; set; } = null!;
    public virtual Actividad TipoActividad { get; set; } = null!;
}