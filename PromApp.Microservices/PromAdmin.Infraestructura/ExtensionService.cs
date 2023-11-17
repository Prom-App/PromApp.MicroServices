using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromAdmin.Core.Interfaces;
using PromAdmin.Infraestructura.Persistencia.Context;
using PromAdmin.Infraestructura.Persistencia.Inicializacion;
using PromAdmin.Infraestructura.Persistencia.Repositorios;

namespace PromAdmin.Infraestructura;

public static class ExtensionService
{
    public static IServiceCollection AgregarDependenciasInfra(this IServiceCollection services,
        IConfiguration configuration)
    {
        // services = AddAuthentication(services, configuration);
        // services = AddSwagger(services);
        services = AddContext(services, configuration);
        // services.AddTransient<IEmailService, EmailService>();
        // services.AddTransient<IAuthService, AuthService>();
        // services.AddScoped<IManageImageService, ManageImageService>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        // services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        // services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        // services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        // services.Configure<StripeSettings>(configuration.GetSection("StripeSetting"));

        return services;
    }
    //
    // private static IServiceCollection AddSwagger(this IServiceCollection services)
    // {
    //     var openApi = new OpenApiInfo
    //     {
    //         Title = "Million Technical Challenge",
    //         Version = "v1",
    //         Description = "API Technical Challenge Million And Up",
    //         Contact = new OpenApiContact
    //         {
    //             Name = "Jeyson Esteban Parra Bedoya",
    //             Email = "estebanparra15@gmail.com",
    //             Url = new Uri("https://www.linkedin.com/in/jeysonparrasdev/")
    //         }
    //     };
    //
    //     services.AddSwaggerGen(x =>
    //     {
    //         openApi.Version = "v1";
    //         x.SwaggerDoc("v1", openApi);
    //
    //         var securityScheme = new OpenApiSecurityScheme
    //         {
    //             Name = "JWT Auth",
    //             Description = "JWT Bearer Token",
    //             In = ParameterLocation.Header,
    //             Type = SecuritySchemeType.Http,
    //             Scheme = "Bearer",
    //             BearerFormat = "JWT",
    //             Reference = new OpenApiReference
    //             {
    //                 Id = JwtBearerDefaults.AuthenticationScheme,
    //                 Type = ReferenceType.SecurityScheme
    //             }
    //         };
    //         x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    //         x.AddSecurityRequirement(new OpenApiSecurityRequirement
    //         {
    //             { securityScheme, Array.Empty<string>() }
    //         });
    //     });
    //     return services;
    // }

    /// <summary>
    /// Agrega Base de datos
    /// </summary>
    /// <param name="services">Colección de servicios para la solución</param>
    /// <param name="configuration">Información extraída de appsettings.json</param>
    /// <returns></returns>
    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = typeof(PromDbContext).Assembly.FullName;
        services.AddDbContext<PromDbContext>(o =>
                o.UseSqlServer(configuration.GetConnectionString("Default"),
                    y => y.MigrationsAssembly(assembly)), ServiceLifetime.Transient
        );

        services.AddTransient<IInicializarBaseDatos, InicializarBaseDatos>();
        services.AddTransient<PoblarBaseDatos>();

        return services;
    }

    /// <summary>
    /// Inicia migración de la base de datos
    /// </summary>
    /// <param name="services">Colección de servicios para la solución</param>
    /// <param name="cancellationToken"></param>
    public static async Task InicializarBaseDatosAsync(this IServiceProvider services,
        CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();

        await scope.ServiceProvider.GetRequiredService<IInicializarBaseDatos>()
            .InicializarBaseDatosAsync(cancellationToken);
    }
}