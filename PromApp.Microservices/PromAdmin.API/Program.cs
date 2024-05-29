using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PromAdmin.API.Middlewares;
using PromAdmin.Core;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Infraestructura;
using PromAdmin.Infraestructura.Persistencia.Context;
using PromAdmin.Utilidades;


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjW35YcndWRGFfVk13Vg==");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

// Add services to the container.
builder.Services.AgregarDependenciasUtilidades(configuration);
builder.Services.AgregarDependenciasInfra(configuration);
builder.Services.AgregarDependenciasApp(configuration);


builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var identityBuilder = builder.Services.AddIdentityCore<Usuario>();
identityBuilder = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);

identityBuilder.AddRoles<IdentityRole>().AddDefaultTokenProviders();
identityBuilder.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<Usuario, IdentityRole>>();

identityBuilder.AddEntityFrameworkStores<PromDbContext>();
identityBuilder.AddSignInManager<SignInManager<Usuario>>();

builder.Services.TryAddSingleton<ISystemClock, SystemClock>();
builder.Services.AddDataProtection();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password = new PasswordOptions()
    {
        RequireDigit = true,
        RequireLowercase = true,
        RequireNonAlphanumeric = false,
        RequiredLength = 8,
        RequireUppercase = true
    };
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//await app.Services.InicializarBaseDatosAsync();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();