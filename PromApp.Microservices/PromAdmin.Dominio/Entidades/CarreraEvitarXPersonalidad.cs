namespace PromAdmin.Dominio.Entidades;

public class CarreraEvitarXPersonalidad
{
    public int IdPersonalidad { get; set; }
    public int IdCarrera { get; set; }
    public virtual Personalidad? Personalidad { get; set; }
    public virtual Carrera? Carrera { get; set; }
}