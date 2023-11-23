using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Infraestructura.Persistencia.Context;
using PromAdmin.Infraestructura.Persistencia.Inicializacion.Recursos;

namespace PromAdmin.Infraestructura.Persistencia.Inicializacion;

public class PoblarBaseDatos
{
    private readonly IConfiguration _configuration;
    private readonly PromDbContext _context;

    public PoblarBaseDatos(IConfiguration configuration, PromDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task SeedDatabaseAsync(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager,
        CancellationToken cancellationToken)
    {
        await PoblarCiudades(cancellationToken);
        await PoblarRolesAsync(roleManager, cancellationToken);
        await PoblarUsuariosAsync(userManager, cancellationToken);
    }

    private async Task PoblarUsuariosAsync(UserManager<Usuario> userManager, CancellationToken cancellationToken)
    {
        if (!userManager.Users.Any())
        {
            var user = new Usuario()
            {
                Nombre = _configuration["Seeds:FirstUser:Name"],
                Email = _configuration["Seeds:FirstUser:Email"],
                UserName = _configuration["Seeds:FirstUser:Username"],
                Telefono = _configuration["Seeds:FirstUser:Phone"],
            };
            await userManager.CreateAsync(user, _configuration["Seeds:FirstUser:Password"]!);
            await userManager.AddToRoleAsync(user!, Roles.SuperAdministrador.ToString());
        }
    }

    private async Task PoblarRolesAsync(RoleManager<IdentityRole> roleManager,
        CancellationToken cancellationToken)
    {
        if (!roleManager.Roles.Any())
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                await roleManager.CreateAsync(new IdentityRole(item.ToString()!));
            }
        }
    }

    private async Task PoblarCiudades(CancellationToken cancellationToken)
    {
        var data = await File.ReadAllTextAsync("../Recursos/Mundo.json", cancellationToken);
        var countries=JsonConvert.DeserializeObject<List<Country>>(data);
        var paises = new List<Pais>();
        countries!.ForEach(async c =>
        {
            var pais = new Pais()
            {
                Nombre = c.Name,
                Iso2 = c.Iso2,
                Iso3 = c.Iso3,
                CodigoTelefonico = c.Phone_code,
                Moneda = c.Currency
            };
            await _context.Paises!.AddAsync(pais, cancellationToken);
            c.States.ForEach(async s =>
            {
                var departamento = new Departamento
                {
                    Nombre = s.Name,
                    Iso3 = s.State_code,
                    IdPais = pais.Id
                };
                await _context.Departamentos!.AddAsync(departamento, cancellationToken);
                s.Cities.ForEach(async ct =>
                {
                    var ciudad = new Ciudad()
                    {
                        Nombre = ct.Name,
                        IdDepartamento = departamento.Id
                    };
                    await _context.Ciudades!.AddAsync(ciudad, cancellationToken);
                });
            });
            await _context.SaveChangesAsync(cancellationToken);
        });
        //todo: leer json mundo y serializar a los datos requeridos
    }

    // private async Task SeedCategories(CancellationToken cancellationToken)
    // {
    //     if (!_context.Categories!.Any())
    //     {
    //         var data =
    //             await File.ReadAllTextAsync("../Store.Infrastructure/Data/category.json", cancellationToken);
    //         var countries = JsonConvert.DeserializeObject<List<Category>>(data);
    //         await _context.Categories!.AddRangeAsync(countries!, cancellationToken);
    //         await _context.SaveChangesAsync(cancellationToken);
    //     }
    // }
    //
    // private async Task SeedProducts(CancellationToken cancellationToken)
    // {
    //     if (!_context.Products!.Any())
    //     {
    //         var data =
    //             await File.ReadAllTextAsync("../Store.Infrastructure/Data/product.json", cancellationToken);
    //         var products = JsonConvert.DeserializeObject<List<Product>>(data);
    //         await _context.Products!.AddRangeAsync(products!, cancellationToken);
    //         await _context.SaveChangesAsync(cancellationToken);
    //     }
    //
    //     await _context.SaveChangesAsync(cancellationToken);
    // }
    //
    // private async Task SeedCountries(CancellationToken cancellationToken)
    // {
    //     if (!_context.Countries!.Any())
    //     {
    //         var data =
    //             await File.ReadAllTextAsync("../Store.Infrastructure/Data/countries.json", cancellationToken);
    //         var countries = JsonConvert.DeserializeObject<List<Country>>(data);
    //         await _context.Countries!.AddRangeAsync(countries!, cancellationToken);
    //         await _context.SaveChangesAsync(cancellationToken);
    //     }
    //  }
    // private async Task SeedBrands(CancellationToken cancellationToken)
    // {
    //     if (!_context.Brands!.Any())
    //     {
    //         var data =
    //             await File.ReadAllTextAsync("../Store.Infrastructure/Data/brand.json", cancellationToken);
    //         var brands = JsonConvert.DeserializeObject<List<Brand>>(data);
    //         await _context.Brands!.AddRangeAsync(brands!, cancellationToken);
    //         await _context.SaveChangesAsync(cancellationToken);
    //     }
    // }
}