using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromApp.Mensajeria.Aplicacion.Interfaces;
using PromApp.Mensajeria.Infraestructura.Email;

namespace PromApp.Mensajeria.Infraestructura;

public static class ExtensionService
{
    public static IServiceCollection AgregarDependenciasInfra(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IEmailService, EmailService>();
        return services;
    }

}