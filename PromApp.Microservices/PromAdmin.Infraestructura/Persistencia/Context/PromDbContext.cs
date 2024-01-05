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
    public virtual DbSet<Avatar>? Avatares { get; set; }
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
    public virtual DbSet<Nacionalidad>? Nacionalidades { get; set; }
    public virtual DbSet<Pais>? Paises { get; set; }
    public virtual DbSet<Parentesco>? Parentescos { get; set; }
    public virtual DbSet<Programa>? TiposPrograma { get; set; }
    public virtual DbSet<Universidad>? Universidades { get; set; }
    public virtual DbSet<Modulo>? Modulos { get; set; }
    public virtual DbSet<Test>? Tests { get; set; }
    public virtual DbSet<Seccion>? Seccion { get; set; }
    public virtual DbSet<Pregunta>? Preguntas { get; set; }
    public virtual DbSet<Respuesta>? Respuestas { get; set; }
    public virtual DbSet<TipoPregunta>? TiposRespuesta { get; set; }
    public virtual DbSet<Cualidad>? Cualidades { get; set; }
    public virtual DbSet<Personalidad>? Personalidades { get; set; }
    public virtual DbSet<CualidadXPersonalidad>? CualidadesXPersonalidad { get; set; }
    public virtual DbSet<TestXUsuario>? TestsXUsuario { get; set; }
    public virtual DbSet<RespuestaXTest>? RespuestasXTest { get; set; }
    public virtual DbSet<MBTIResultado>? MbtiResultados { get; set; }
    public virtual DbSet<Actitud>? Actitudes { get; set; }
    public virtual DbSet<Habilidad>? Habilidades { get; set; }
    public virtual DbSet<Interes>? Intereses { get; set; }
    public virtual DbSet<ActitudXCarrera>? ActitudesXCarrera { get; set; }
    public virtual DbSet<HabilidadXCarrera>? HabilidadesXCarrera { get; set; }
    public virtual DbSet<InteresXCarrera>? InteresesXCarrera { get; set; }
    public virtual DbSet<CarreraRecomendadaXPersonalidad>? CarrerasRecomendads { get; set; }
    public virtual DbSet<CarreraFuturoXPersonalidad>? CarrerasFuturo { get; set; }
    public virtual DbSet<CarreraEvitarXPersonalidad>? CarrerasEvitar { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Actitud>().ToTable("Actitud").HasIndex(x => x.NombreActitud).IsUnique();
        builder.Entity<Habilidad>().ToTable("Habilidad").HasIndex(x => x.NombreHabilidad).IsUnique();
        builder.Entity<Interes>().ToTable("Interes").HasIndex(x => x.NombreInteres).IsUnique();

        builder.Entity<ActitudXCarrera>(e =>
        {
            e.HasKey(x => new { x.IdActitud, x.IdCarrera });
            e.ToTable("ActitudesXCarrera");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Actitud).WithMany()
                .HasForeignKey(x => x.IdActitud).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<HabilidadXCarrera>(e =>
        {
            e.HasKey(x => new { x.IdHabilidad, x.IdCarrera });
            e.ToTable("HabilidadesXCarrera");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Habilidad).WithMany()
                .HasForeignKey(x => x.IdHabilidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<InteresXCarrera>(e =>
        {
            e.HasKey(x => new { x.IdInteres, x.IdCarrera });
            e.ToTable("InteresesXCarrera");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Interes).WithMany()
                .HasForeignKey(x => x.IdInteres).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CarreraEvitarXPersonalidad>(e =>
        {
            e.HasKey(x => new { x.IdPersonalidad, x.IdCarrera });
            e.ToTable("CarrerasEvitar");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Personalidad).WithMany(k => k.CarrerasEvitar)
                .HasForeignKey(x => x.IdPersonalidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CarreraRecomendadaXPersonalidad>(e =>
        {
            e.HasKey(x => new { x.IdPersonalidad, x.IdCarrera });
            e.ToTable("CarrerasRecomendadas");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Personalidad).WithMany(k => k.CarrerasRecomendadas)
                .HasForeignKey(x => x.IdPersonalidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CarreraFuturoXPersonalidad>(e =>
        {
            e.HasKey(x => new { x.IdPersonalidad, x.IdCarrera });
            e.ToTable("CarrerasFuturo");
            e.HasOne(d => d.Carrera).WithMany()
                .HasForeignKey(c => c.IdCarrera).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Personalidad).WithMany(k => k.CarrerasFuturo)
                .HasForeignKey(x => x.IdPersonalidad).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Agencia>().ToTable("Agencia").HasIndex(x => x.Nombre).IsUnique();
        builder.Entity<Avatar>().ToTable("Avatar").HasIndex(x => x.Nombre).IsUnique();
        builder.Entity<Modulo>().ToTable("Modulo").HasIndex(x => x.NombreModulo).IsUnique();
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
        builder.Entity<Test>(e =>
        {
            e.ToTable("Test");
            e.Property(x => x.NombreTest).HasMaxLength(255);
            e.HasIndex(x => new { x.NombreTest, x.IdModulo }).IsUnique();
            e.HasOne(d => d.Modulo).WithMany(p => p.Pruebas)
                .HasForeignKey(d => d.IdModulo).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<TestXUsuario>(e =>
        {
            e.ToTable("TestXUsuario");
            e.HasOne(t => t.Usuario).WithMany(u => u.TestsXUsuario)
                .HasForeignKey(x => x.IdUsuario);
            e.HasOne(t => t.Test).WithMany(u => u.TestsXUsuario)
                .HasForeignKey(x => x.IdTest);
        });

        builder.Entity<RespuestaXTest>(e =>
        {
            e.ToTable("RespuestaXTest");
            e.HasOne(x => x.Test).WithMany(y => y.RespuestasTest)
                .HasForeignKey(z => z.IdTestUsuario);
        });

        builder.Entity<MBTIResultado>(e =>
        {
            e.ToTable("MBTIResultado");
            e.HasIndex(x => new { x.IdUsuario, x.IdTestXUsuario }).IsUnique();
        });
        builder.Entity<Seccion>(e =>
        {
            e.ToTable("Seccion");
            e.Property(x => x.NombreSeccion).HasMaxLength(255);
            e.HasIndex(x => new { x.NombreSeccion, x.IdTest }).IsUnique();
            e.HasOne(d => d.Test).WithMany(p => p.Secciones)
                .HasForeignKey(d => d.IdTest).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Pregunta>(e =>
        {
            e.ToTable("Pregunta");
            e.HasIndex(x => new { x.Enunciado, x.IdTest }).IsUnique();
            e.HasOne(d => d.Seccion).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.IdSeccion).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Prueba).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.IdTest).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(d => d.TipoPregunta).WithMany(p => p.Preguntas)
                .HasForeignKey(d => d.IdTipoPregunta).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<TipoPregunta>().ToTable("TipoPregunta").HasIndex(x => x.Tipo).IsUnique();
        builder.Entity<Respuesta>(e =>
        {
            e.ToTable("Respuesta");
            e.HasIndex(x => new { x.Enunciado, x.IdPregunta }).IsUnique();
            e.HasOne(d => d.Pregunta).WithMany(p => p.Respuestas)
                .HasForeignKey(d => d.IdPregunta).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Cualidad>().ToTable("Cualidad").HasIndex(x => x.Caracteristica).IsUnique();
        builder.Entity<Personalidad>(e =>
        {
            e.ToTable("Personalidad").HasIndex(x => x.Codigo).IsUnique();
            e.HasIndex(x => x.Definicion).IsUnique();
        });
        builder.Entity<CualidadXPersonalidad>(e =>
        {
            e.HasKey(x => new { x.IdCualidad, x.IdPersonalidad });
            e.ToTable("CualidadXPersonalidad");
            e.HasOne(d => d.Cualidad).WithMany(k=>k.CualidadesXPersonalidad)
                .HasForeignKey(c => c.IdCualidad).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Personalidad).WithMany(k => k.CualidadesXPersonalidad)
                .HasForeignKey(c => c.IdPersonalidad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<CaracteristicaXUniversidad>(e =>
        {
            e.HasKey(x => new { x.IdCaracteristica, x.IdCampus });
            e.ToTable("CaracteristicasXUniversidad");
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
            e.HasKey(x => new { x.IdUniversidad, x.IdCarrera });
            e.ToTable("CarreraXUniversidad");
            e.Property(x => x.Costo).HasColumnType("decimal(18, 2)");
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
                .HasForeignKey(c => c.IdDemografia).OnDelete(DeleteBehavior.Cascade);
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
            e.HasOne(c => c.Usuario).WithMany()
                .HasForeignKey(x => x.IdUsuario).OnDelete(DeleteBehavior.NoAction);
            e.HasOne(c => c.UsuarioContacto).WithMany()
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

        builder.Entity<Nacionalidad>(e =>
        {
            e.ToTable("Nacionalidad").HasIndex(x => x.Descripcion).IsUnique();
            e.HasOne(x => x.Pais).WithOne(x => x.Nacionalidad).HasForeignKey<Nacionalidad>(x => x.IdPais);
        });
        builder.Entity<Geografia>().ToTable("Geografia").HasIndex(x => x.Caracteristica).IsUnique();
        builder.Entity<Idioma>().ToTable("Idioma").HasIndex(x => x.Lenguaje).IsUnique();
        builder.Entity<IdiomaXUniversidad>(e =>
        {
            e.HasKey(x => new { x.IdUniversidad, x.IdIdioma });
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
            e.HasKey(x => new { x.IdColegio, x.IdAcreditacion });
            e.ToTable("TipoAcreditacionXColegio");
            e.HasOne(d => d.TipoAcreditacion).WithMany()
                .HasForeignKey(d => d.IdAcreditacion).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.Colegio).WithMany()
                .HasForeignKey(d => d.IdColegio).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Actividad>().ToTable("TipoActividad").HasIndex(x => x.TipoActividad).IsUnique();
        builder.Entity<TipoActividadXCampus>(e =>
        {
            e.HasKey(x => new { x.IdCampus, x.IdTipoActividad });
            e.ToTable("TipoActividadXCampus");
            e.HasOne(d => d.Campus).WithMany()
                .HasForeignKey(d => d.IdCampus).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(d => d.TipoActividad).WithMany()
                .HasForeignKey(d => d.IdTipoActividad).OnDelete(DeleteBehavior.Cascade);
        });
        builder.Entity<Aplicacion>().ToTable("TipoAplicacion").HasIndex(x => x.TipoAplicacion).IsUnique();
        builder.Entity<Programa>().ToTable("TipoPrograma").HasIndex(x => x.TipoPrograma).IsUnique();
        builder.Entity<TipoProgramaXUniversidad>(e =>
        {
            e.HasKey(x => new { x.IdTipoPrograma, x.IdUniversidad });
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
            e.HasOne(x => x.Avatar).WithMany(c => c.Usuarios).HasForeignKey(x => x.IdAvatar);
            e.HasOne(u => u.Nacionalidad).WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.IdNacionalidad).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(u => u.Nacionalidad2).WithMany()
                .HasForeignKey(x => x.IdNacionalidad2).OnDelete(DeleteBehavior.NoAction);
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
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=dbPromApp;User Id=sa;Password=Snider3901*;TrustServerCertificate=true;");
        }
    }
}