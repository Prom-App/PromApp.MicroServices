using Newtonsoft.Json;

namespace PromAdmin.Infraestructura.Persistencia.Inicializacion.Recursos;

public class Mundo
{
    
}
public class City
{
    public string? Name { get; set; }
}

public class Country
{
    public string? Name { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3 { get; set; }
    [JsonProperty("phonecode")]
    public string? PhoneCode { get; set; }
    public string? Currency { get; set; }
    public List<State>? States { get; set; }
}

public class State
{
    public string? Name { get; set; }
    [JsonProperty("state_code")]
    public string? StateCode { get; set; }
    public List<City>? Cities { get; set; }
}