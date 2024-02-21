using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromAdmin.Utilidades.Interfaces;
using PromAdmin.Utilidades.Servicios;

namespace PromAdmin.Utilidades;

public static class ExtensionService
{
    public static IServiceCollection AgregarDependenciasUtilidades(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IGenerarPdf,GenerarPdf>();
        return services;
    }
}