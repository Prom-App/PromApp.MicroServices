using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PromAdmin.Utilidades;

public static class ExtensionService
{
    public static IServiceCollection AgregarDependenciasUtilidades(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}