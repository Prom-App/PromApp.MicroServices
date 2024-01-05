namespace PromAdmin.Dominio.Entidades;

public class CarreraRecomendadaXPersonalidad
{
    public string? CodigoPersonalidad { get; set; }
    public int IdCarrera { get; set; }
    public virtual Personalidad? Personalidad { get; set; }
    public virtual Carrera? Carrera { get; set; }
}