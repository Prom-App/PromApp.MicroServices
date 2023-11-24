using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PromAdmin.Core.Interfaces;
using PromAdmin.Dominio.Entidades;
using PromAdmin.Infraestructura.Persistencia.Context;
using PromAdmin.Infraestructura.Persistencia.Inicializacion.Recursos;

namespace PromAdmin.Infraestructura.Persistencia.Inicializacion;

public class PoblarBaseDatos
{
    private readonly IConfiguration _configuration;
    private readonly PromDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public PoblarBaseDatos(IConfiguration configuration, PromDbContext context, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _context = context;
        _unitOfWork = unitOfWork;
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
            await userManager.AddToRoleAsync(user!, ListaRoles.SuperAdministrador.ToString());
        }
    }

    private async Task PoblarRolesAsync(RoleManager<IdentityRole> roleManager,
        CancellationToken cancellationToken)
    {
        if (!roleManager.Roles.Any())
        {
            foreach (var item in Enum.GetValues(typeof(ListaRoles)))
            {
                await roleManager.CreateAsync(new IdentityRole(item.ToString()!));
            }
        }
    }

    private async Task PoblarCiudades(CancellationToken cancellationToken)
    {
        var data = await File.ReadAllTextAsync(
            "../PromAdmin.Infraestructura/Persistencia/Inicializacion/Recursos/Mundo.json", cancellationToken);
        var countries = JsonConvert.DeserializeObject<List<Country>>(data);
        var paises = new List<Pais>();
        countries!.ForEach(c =>
        {
            var pais = _context.Paises!.FirstOrDefault(x => x.Nombre == c.Name)!;
            if (pais is null)
            {
                pais = new Pais()
                {
                    Nombre = c.Name,
                    Iso2 = c.Iso2,
                    Iso3 = c.Iso3,
                    CodigoTelefonico = c.Phone_code,
                    Moneda = c.Currency
                };
                _context.Paises!.Add(pais);
                _context.SaveChanges();
                pais = _context.Paises!.FirstOrDefault(x => x.Nombre == c.Name)!;
            }

            var idPais = pais.Id;
            c.States.ForEach(s =>
            {
                var departamento = _context.Departamentos!.FirstOrDefault(
                    x => x.Nombre == s.Name && x.IdPais == idPais)!;
                if (departamento is null)
                {
                    departamento = new Departamento
                    {
                        Nombre = s.Name,
                        Iso3 = s.State_code,
                        IdPais = idPais
                    };
                    _context.Departamentos!.Add(departamento);
                    _context.SaveChanges();
                    departamento = _context.Departamentos!.FirstOrDefault(
                        x => x.Nombre == s.Name && x.IdPais == pais!.Id)!;
                }

                var idDep = departamento.Id;
                s.Cities.ForEach(ct =>
                {
                    var ciudad = _context.Ciudades!.FirstOrDefault(
                        x => x.Nombre == ct.Name && x.IdDepartamento == idDep);
                    if (ciudad is not null) return;
                    {
                        ciudad = new Ciudad()
                        {
                            Nombre = ct.Name,
                            Abreviatura = ct.Name.Length > 2 ? ct.Name.Substring(0, 3).ToUpper() : ct.Name.ToUpper(),
                            IdDepartamento = idDep
                        };
                        _context.Ciudades!.Add(ciudad);
                        _context.SaveChanges();
                    }
                });
            });
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