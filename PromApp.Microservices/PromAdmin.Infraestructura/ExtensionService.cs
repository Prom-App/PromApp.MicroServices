using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PromAdmin.Core.Interfaces;
using PromAdmin.Core.Interfaces.Seguridad;
using PromAdmin.Core.Modelos.Token;
using PromAdmin.Infraestructura.Compartido.Utilidades;
using PromAdmin.Infraestructura.Persistencia.Context;
using PromAdmin.Infraestructura.Persistencia.Inicializacion;
using PromAdmin.Infraestructura.Persistencia.Repositorios;
using PromAdmin.Infraestructura.Servicios.Seguridad;

namespace PromAdmin.Infraestructura;

public static class ExtensionService
{
    public static IServiceCollection AgregarDependenciasInfra(this IServiceCollection services,
        IConfiguration configuration)
    {
        services = AddAuthentication(services, configuration);
        services = AddSwagger(services);
        services = AddContext(services, configuration);
        // services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IAutenticacionService, AutenticacionService>();

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        // services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        return services;
    }
    
    /// <summary>
    /// Add JWT Auth
    /// </summary>
    /// <param name="services">Services Collection to use in the solution</param>
    /// <param name="configuration">Data extracted from appsettings.json</param>
    /// <returns></returns>
    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Emisor"],
                    ValidAudience = configuration["JwtSettings:Audiencia"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secreto"]!))
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = x =>
                    {
                        x.NoResult();
                        x.Response.StatusCode = 500;
                        x.Response.ContentType = "text/plain";
                        return x.Response.WriteAsync(x.Exception.ToString());
                    },
                    OnChallenge = x =>
                    {
                        x.HandleResponse();
                        x.Response.StatusCode = 401;
                        x.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(Result.FailAsync("No estás autorizado"));
                        return x.Response.WriteAsync(result);
                    },
                    OnForbidden = x =>
                    {
                        x.Response.StatusCode = 403;
                        x.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(Result.FailAsync("No estás autorizado"));
                        return x.Response.WriteAsync(result);
                    }
                };
            });
        return services;
    }
    
    private static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        var openApi = new OpenApiInfo
        {
            Title = "Prom App Admin",
            Version = "v1",
            Description = "API Modulo Administrador de Prom App",
            Contact = new OpenApiContact
            {
                Name = "Jeyson Esteban Parra Bedoya",
                Email = "tecnologia@promapp.ai",
                Url = new Uri("https://www.promapp.ai")
            }
        };
    
        services.AddSwaggerGen(x =>
        {
            openApi.Version = "v1";
            x.SwaggerDoc("v1", openApi);
    
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Auth",
                Description = "JWT Bearer Token",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };
            x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, Array.Empty<string>() }
            });
        });
        return services;
    }

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