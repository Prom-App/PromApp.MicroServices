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
        var username = "Sistema";
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

    public virtual DbSet<Acreditacion>? TiposAcreditacion { get; set; }
    public virtual DbSet<Actividad>? Actividades { get; set; }
    public virtual DbSet<Agencia>? Agencias { get; set; }
    public virtual DbSet<Aplicacion>? TiposAplicacion { get; set; }
    public virtual DbSet<Campus>? Sedes { get; set; }
    public virtual DbSet<CaracteristicaXUniversidad> CaracteristicasXUniversidad { get; set; }
    public virtual DbSet<Carrera>? Carreras { get; set; }
    public virtual DbSet<CarreraRelacionada>? CarrerasRelacionadas { get; set; }
    public virtual DbSet<CarreraXUniversidad> CarreraXUniversidad { get; set; }
    public virtual DbSet<Ciudad>? Ciudades { get; set; }
    public virtual DbSet<Colegio>? Colegios { get; set; }
    public virtual DbSet<Contacto>? Contactos { get; set; }
    public virtual DbSet<Demografia>? Demografia { get; set; }
    public virtual DbSet<Departamento>? Departamentos { get; set; }
    public virtual DbSet<Genero>? Generos { get; set; }
    public virtual DbSet<Geografia>? Geografia { get; set; }
    public virtual DbSet<Idioma>? Idiomas { get; set; }
    public virtual DbSet<IdiomaXUniversidad> IdiomasXuniversidad { get; set; }
    public virtual DbSet<Pais>? Paises { get; set; }
    public virtual DbSet<Parentesco>? Parentescos { get; set; }
    public virtual DbSet<Programa>? TiposPrograma { get; set; }
    public virtual DbSet<Universidad>? Universidades { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Agencia>().ToTable("Agencia").HasIndex(x => x.Nombre).IsUnique();
        builder.Entity<Campus>(e =>
        {
            e.ToTable("Campus");
            e.Property(c => c.LaFiesta).HasMaxLength(5);
            e.Property(x => x.Nombre).HasMaxLength(255);

            e.HasIndex(x => new { x.Nombre, x.IdUniversidad, x.IdCiudad }).IsUnique();
            e.HasOne(d => d.Ciudad).WithMany(p => p.Campus)
                .HasForeignKey(d => d.IdCiudad);

            e.HasOne(d => d.Universidad).WithMany(p => p.Campus)
                .HasForeignKey(d => d.IdUniversidad);
        });
        builder.Entity<CaracteristicaXUniversidad>(e =>
        {
            e.HasNoKey().ToTable("CaracteristicasXUniversidad");
            e.HasIndex(x => new { x.IdCaracteristica, x.IdCampus }).IsUnique();
            e.HasOne(d => d.Campus).WithMany()
                .HasForeignKey(c => c.IdCampus).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Geografia).WithMany()
                .HasForeignKey(c => c.IdCaracteristica).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Carrera>(e =>
        {
            e.ToTable("Carrera");
            e.HasIndex(x => new { x.Nombre, x.IdTipoPrograma }).IsUnique();
            e.HasOne(d => d.TipoPrograma).WithMany(p => p.Carreras)
                .HasForeignKey(x => x.IdTipoPrograma).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CarreraRelacionada>(e =>
        {
            e.ToTable("CarreraRelacionada");
            e.HasIndex(x => new { x.Nombre, x.IdCarrera }).IsUnique();
            e.HasOne(d => d.Carrera).WithMany(p => p.CarrerasRelacionadas)
                .HasForeignKey(a => a.IdCarrera).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CarreraXUniversidad>(e =>
        {
            e.ToTable("CarreraXUniversidad");
            e.Property(x => x.Costo).HasColumnType("decimal(18, 2)");
            e.HasIndex(x => new { x.IdUniversidad, x.IdCarrera }).IsUnique();
            e.HasOne(d => d.Carrera).WithMany(p => p.CarrerasXuniversidad)
                .HasForeignKey(x => x.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Universidad).WithMany(p => p.CarrerasXuniversidad)
                .HasForeignKey(x => x.IdUniversidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Ciudad>(e =>
        {
            e.ToTable("Ciudad");
            e.HasIndex(x => new { x.Nombre, x.IdDepartamento }).IsUnique();
            e.HasOne(c => c.Demografia).WithMany(d => d.Ciudades)
                .HasForeignKey(c => c.IdDepartamento).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(c => c.Departamento).WithMany(d => d.Ciudades)
                .HasForeignKey(x => x.IdDepartamento).IsRequired().OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Colegio>(e =>
        {
            e.ToTable("Colegio");
            e.HasIndex(x => new { x.Nombre, x.IdCiudad }).IsUnique();
            e.HasOne(c => c.Ciudad).WithMany(d => d.Colegios)
                .HasForeignKey(x => x.IdCiudad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Contacto>(e =>
        {
            e.ToTable("Contacto");
            e.HasOne(c => c.Parentesco).WithMany(p => p.Contactos)
                .HasForeignKey(x => x.IdParentesco).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(c => c.Usuario).WithMany(p => p.Contactos)
                .HasForeignKey(x => x.IdUsuario).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(c => c.UsuarioContacto).WithMany(d => d.Contactos)
                .HasForeignKey(x => x.IdUsuarioContacto).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.IdUsuario, x.IdParentesco, x.Correo }).IsUnique();
        });
        builder.Entity<Demografia>().ToTable("Demografia").HasIndex(e => e.Tamaño).IsUnique();
        builder.Entity<Departamento>(e =>
        {
            e.ToTable("Departamento");
            e.HasOne(x => x.Pais).WithMany(p => p.Departamentos)
                .HasForeignKey(x => x.IdPais).OnDelete(DeleteBehavior.Cascade);
            e.HasIndex(x => new { x.IdPais, x.Nombre });
        });
        builder.Entity<Genero>().ToTable("Genero").HasIndex(x => x.TipoGenero).IsUnique();
        builder.Entity<Geografia>().ToTable("Geografia").HasIndex(x => x.Caracteristica).IsUnique();
        builder.Entity<Idioma>().ToTable("Idioma").HasIndex(x => x.Lenguaje).IsUnique();
        builder.Entity<IdiomaXUniversidad>(e =>
        {
            e.ToTable("IdiomaXUniversidad");
            e.HasOne(i => i.Idioma).WithMany()
                .HasForeignKey(x => x.IdIdioma).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(i => i.Universidad).WithMany()
                .HasForeignKey(x => x.IdUniversidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Pais>().ToTable("Pais").HasIndex(x => x.Nombre).IsUnique();
        builder.Entity<Parentesco>().ToTable("Parentesco").HasIndex(x => x.TipoParentesco).IsUnique();
        builder.Entity<Acreditacion>().ToTable("TipoAcreditacion").HasIndex(x => x.TipoAcreditacion).IsUnique();
        builder.Entity<TipoAcreditacionXColegio>(e =>
        {
            e.ToTable("TipoAcreditacionXColegio");
            e.HasOne(d => d.TipoAcreditacion).WithMany()
                .HasForeignKey(d => d.IdAcreditacion).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Colegio).WithMany()
                .HasForeignKey(d => d.IdColegio).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Actividad>().ToTable("TipoActividad").HasIndex(x => x.TipoActividad).IsUnique();
        builder.Entity<TipoActividadXUniversidad>(e =>
        {
            e.ToTable("TipoActividadXUniversidad");
            e.HasOne(d => d.Campus).WithMany()
                .HasForeignKey(d => d.IdCampus).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.TipoActividad).WithMany()
                .HasForeignKey(d => d.IdTipoActividad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Aplicacion>().ToTable("TipoAplicacion").HasIndex(x => x.TipoAplicacion).IsUnique();
        builder.Entity<Programa>().ToTable("TipoPrograma").HasIndex(x => x.TipoPrograma).IsUnique();
        builder.Entity<TipoProgramaXUniversidad>(e =>
        {
            e.ToTable("TipoProgramaXUniversidad");
            e.HasOne(d => d.TipoPrograma).WithMany()
                .HasForeignKey(d => d.IdTipoPrograma).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Universidad).WithMany()
                .HasForeignKey(d => d.IdUniversidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Universidad>(e =>
        {
            e.ToTable("Universidad");
            e.HasIndex(x => new { x.IdPais, x.Nombre }).IsUnique();
            e.HasOne(u => u.Agencia).WithMany(a => a.Universidades)
                .HasForeignKey(x => x.IdAgencia).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(u => u.Pais).WithMany(a => a.Universidades)
                .HasForeignKey(x => x.IdPais).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(u => u.TipoAplicacion).WithMany(a => a.Universidades)
                .HasForeignKey(x => x.IdTipoAplicacion).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Usuario>(e =>
        {
            e.Property(x => x.Id).HasMaxLength(36);
            e.Property(x => x.NormalizedUserName).HasMaxLength(90);
            e.HasOne(u => u.Ciudad).WithMany(c => c.Usuarios)
                .HasForeignKey(x => x.IdCiudad);
            e.HasOne(u => u.Colegio).WithMany(c => c.Usuarios)
                .HasForeignKey(x => x.IdColegio);
            e.HasOne(u => u.Genero).WithMany(c => c.Usuarios)
                .HasForeignKey(x => x.IdGenero);
        });
        builder.Entity<IdentityRole>(e =>
        {
            e.Property(x => x.Id).HasMaxLength(36);
            e.Property(x => x.NormalizedName).HasMaxLength(36);
        });

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
        }
    }
}