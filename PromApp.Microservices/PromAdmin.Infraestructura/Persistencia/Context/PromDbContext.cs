using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PromAdmin.Dominio.Compartido;
using PromAdmin.Dominio.Entidades;

namespace PromAdmin.Infraestructura.Persistencia.Context;

public class PromDbContext : IdentityDbContext<Usuario>
{
    public PromDbContext()
    {
    }

    public PromDbContext(DbContextOptions<PromDbContext> options) : base(options)
    {
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var username = "System";
        foreach (var entry in ChangeTracker.Entries<EntidadBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.FechaCreacion = DateTime.Now;
                    entry.Entity.CreadoPor = username;
                    break;
                case EntityState.Modified:
                    entry.Entity.FechaModificacion = DateTime.Now;
                    entry.Entity.ModificadoPor = username;
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public virtual DbSet<Acreditacion>? TiposAcreditaciones { get; set; }
    public virtual DbSet<Actividad>? Actividades { get; set; }
    public virtual DbSet<Agencia>? Agencias { get; set; }
    public virtual DbSet<Aplicacion>? TiposAplicacion { get; set; }
    public virtual DbSet<Campus>? Sedes { get; set; }
    public virtual DbSet<Carrera>? Carreras { get; set; }
    public virtual DbSet<CarreraRelacionada>? CarrerasRelacionadas { get; set; }
    public virtual DbSet<Ciudad>? Ciudades { get; set; }
    public virtual DbSet<Colegio>? Colegios { get; set; }
    public virtual DbSet<Contacto>? Contactos { get; set; }
    public virtual DbSet<Demografia>? Demografia { get; set; }
    public virtual DbSet<Departamento>? Departamentos { get; set; }
    public virtual DbSet<Genero>? Generos { get; set; }
    public virtual DbSet<Geografia>? Geografia { get; set; }
    public virtual DbSet<Idioma>? Idiomas { get; set; }
    public virtual DbSet<Pais>? Paises { get; set; }
    public virtual DbSet<Parentesco>? Parentescos { get; set; }
    public virtual DbSet<Programa>? TiposPrograma { get; set; }
    public virtual DbSet<Universidad>? Universidades { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Acreditacion>().ToTable("TipoAcreditacion");
        builder.Entity<Actividad>().ToTable("TipoActividad");
        builder.Entity<Agencia>().ToTable("Agencia");
        builder.Entity<Aplicacion>().ToTable("Aplicacion");
        builder.Entity<Campus>().ToTable("Campus");
        builder.Entity<Carrera>().ToTable("Carrera");
        builder.Entity<CarreraRelacionada>().ToTable("CarreraRelacionada");
        builder.Entity<Ciudad>().ToTable("Ciudad");
        builder.Entity<Colegio>().ToTable("Colegio");
        builder.Entity<Contacto>().ToTable("Contacto");
        builder.Entity<Demografia>().ToTable("Demografia");
        builder.Entity<Departamento>().ToTable("Departamento");
        builder.Entity<Genero>().ToTable("Genero");
        builder.Entity<Geografia>().ToTable("Geografia");
        builder.Entity<Idioma>().ToTable("Idioma");
        builder.Entity<Pais>().ToTable("Pais");
        builder.Entity<Parentesco>().ToTable("Parentesco");
        builder.Entity<Programa>().ToTable("Programa");
        builder.Entity<Universidad>().ToTable("Universidad");
        
        base.OnModelCreating(builder);
        
        
        
        builder.Entity<Usuario>().Property(x => x.Id).HasMaxLength(36);
        builder.Entity<Usuario>().Property(x => x.NormalizedUserName).HasMaxLength(90);
        builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(36);
        builder.Entity<IdentityRole>().Property(x => x.NormalizedName).HasMaxLength(90);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=dbFerFashion;User Id=sa;Password=Snider3901*;TrustServerCertificate=true;");
        }
    }
}