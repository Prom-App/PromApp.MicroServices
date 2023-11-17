using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromAdmin.Core.Behaviors;
using PromAdmin.Core.Mapeos;

namespace PromAdmin.Core;

public static class ExtensionServices
{
    public static IServiceCollection AgregarDependenciasApp(this IServiceCollection services,
        IConfiguration configuration)
    {
        var mappingConfig = new MapperConfiguration(c =>
        {
            c.AddProfile(new PerfilMapeo());
        });
        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        
        return services;
    }
}