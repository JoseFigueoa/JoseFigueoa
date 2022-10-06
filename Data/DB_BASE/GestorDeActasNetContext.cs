using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gestor2._0.Data.DB_BASE
{
    public partial class GestorDeActasNetContext : DbContext
    {
        public GestorDeActasNetContext()
        {
        }

        public GestorDeActasNetContext(DbContextOptions<GestorDeActasNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bautizos> Bautizos { get; set; }
        public virtual DbSet<Confirmaciones> Confirmaciones { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<EventoEstados> EventoEstados { get; set; }
        public virtual DbSet<EventoPersonas> EventoPersonas { get; set; }
        public virtual DbSet<EventoTipoPersonas> EventoTipoPersonas { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Matrimonios> Matrimonios { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Telefonos> Telefonos { get; set; }
        public virtual DbSet<TipoEventos> TipoEventos { get; set; }
        public virtual DbSet<TipoPersonas> TipoPersonas { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LocalDb;Database=GestorDeActasNet;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bautizos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaEvento)
                    .HasColumnName("fecha_evento")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Folio).HasColumnName("folio");

                entity.Property(e => e.IdMadre).HasColumnName("id_Madre");

                entity.Property(e => e.IdMadrina).HasColumnName("id_Madrina");

                entity.Property(e => e.IdNombre).HasColumnName("id_nombre");

                entity.Property(e => e.IdPadre).HasColumnName("id_Padre");

                entity.Property(e => e.IdPadrino).HasColumnName("id_Padrino");

                entity.Property(e => e.Libro).HasColumnName("libro");

                entity.Property(e => e.NoRegistro)
                    .HasColumnName("no_registro")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('B'+right('000000'+CONVERT([varchar],[id]),(6)))");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMadreNavigation)
                    .WithMany(p => p.BautizosIdMadreNavigation)
                    .HasForeignKey(d => d.IdMadre)
                    .HasConstraintName("FK_Bautizos_personas2");

                entity.HasOne(d => d.IdMadrinaNavigation)
                    .WithMany(p => p.BautizosIdMadrinaNavigation)
                    .HasForeignKey(d => d.IdMadrina)
                    .HasConstraintName("FK_Bautizos_personas4");

                entity.HasOne(d => d.IdNombreNavigation)
                    .WithMany(p => p.BautizosIdNombreNavigation)
                    .HasForeignKey(d => d.IdNombre)
                    .HasConstraintName("FK_Bautizos_personas");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithMany(p => p.BautizosIdPadreNavigation)
                    .HasForeignKey(d => d.IdPadre)
                    .HasConstraintName("FK_Bautizos_personas1");

                entity.HasOne(d => d.IdPadrinoNavigation)
                    .WithMany(p => p.BautizosIdPadrinoNavigation)
                    .HasForeignKey(d => d.IdPadrino)
                    .HasConstraintName("FK_Bautizos_personas3");
            });

            modelBuilder.Entity<Confirmaciones>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaEvento)
                    .HasColumnName("fecha_evento")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Folio).HasColumnName("folio");

                entity.Property(e => e.IdMadrina).HasColumnName("id_Madrina");

                entity.Property(e => e.IdPadrino).HasColumnName("id_Padrino");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Libro).HasColumnName("libro");

                entity.Property(e => e.NoRegistro)
                    .HasColumnName("no_registro")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('C'+right('000000'+CONVERT([varchar],[id]),(6)))");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMadrinaNavigation)
                    .WithMany(p => p.ConfirmacionesIdMadrinaNavigation)
                    .HasForeignKey(d => d.IdMadrina)
                    .HasConstraintName("FK_Confirmaciones_personas2");

                entity.HasOne(d => d.IdPadrinoNavigation)
                    .WithMany(p => p.ConfirmacionesIdPadrinoNavigation)
                    .HasForeignKey(d => d.IdPadrino)
                    .HasConstraintName("FK_Confirmaciones_personas1");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.ConfirmacionesIdPersonaNavigation)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Confirmaciones_personas");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.ToTable("departamentos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Departamento)
                    .IsRequired()
                    .HasColumnName("departamento")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPais).HasColumnName("id_pais");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_departamentos_paises");
            });

            modelBuilder.Entity<EventoEstados>(entity =>
            {
                entity.ToTable("evento_estados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasColumnName("nombre_estado")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EventoPersonas>(entity =>
            {
                entity.ToTable("evento_personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.IdEventoPersona).HasColumnName("id_evento_persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventoPersonas)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evento_personas_eventos1");

                entity.HasOne(d => d.IdEventoPersonaNavigation)
                    .WithMany(p => p.EventoPersonas)
                    .HasForeignKey(d => d.IdEventoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evento_personas_evento_tipo_personas");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.EventoPersonas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_evento_personas_personas");
            });

            modelBuilder.Entity<EventoTipoPersonas>(entity =>
            {
                entity.ToTable("evento_tipo_personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventoTipoPersona)
                    .IsRequired()
                    .HasColumnName("evento_tipo_persona")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.ToTable("eventos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaPrograma)
                    .HasColumnName("fecha_programa")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdTipoEvento).HasColumnName("id_tipo_evento");

                entity.Property(e => e.NoFolio).HasColumnName("no_folio");

                entity.Property(e => e.NoLibro).HasColumnName("no_libro");

                entity.Property(e => e.NoRegistro).HasColumnName("no_registro");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eventos_evento_estados");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_eventos_tipo_eventos");
            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.ToTable("generos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnName("genero")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Matrimonios>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaEvento)
                    .HasColumnName("fecha_evento")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Folio).HasColumnName("folio");

                entity.Property(e => e.IdEsposa).HasColumnName("id_esposa");

                entity.Property(e => e.IdEsposo).HasColumnName("id_esposo");

                entity.Property(e => e.Libro).HasColumnName("libro");

                entity.Property(e => e.NoRegistro)
                    .HasColumnName("no_registro")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('M'+right('000000'+CONVERT([varchar],[id]),(6)))");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEsposaNavigation)
                    .WithMany(p => p.MatrimoniosIdEsposaNavigation)
                    .HasForeignKey(d => d.IdEsposa)
                    .HasConstraintName("FK_Matrimonios_personas1");

                entity.HasOne(d => d.IdEsposoNavigation)
                    .WithMany(p => p.MatrimoniosIdEsposoNavigation)
                    .HasForeignKey(d => d.IdEsposo)
                    .HasConstraintName("FK_Matrimonios_personas");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.ToTable("paises");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasColumnName("pais")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.ToTable("personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoCasada)
                    .HasColumnName("apellido_casada")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.IdTipoPersona).HasColumnName("id_tipo_persona");

                entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primer_apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasColumnName("primer_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.TercerNombre)
                    .HasColumnName("tercer_nombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personas_generos");

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personas_tipo_personas");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdUbicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personas_ubicaciones");
            });

            modelBuilder.Entity<Telefonos>(entity =>
            {
                entity.ToTable("telefonos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK_telefonos_personas");
            });

            modelBuilder.Entity<TipoEventos>(entity =>
            {
                entity.ToTable("tipo_eventos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(2000);

                entity.Property(e => e.TipoEvento)
                    .IsRequired()
                    .HasColumnName("tipo_evento")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TipoPersonas>(entity =>
            {
                entity.ToTable("tipo_personas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoPersona)
                    .IsRequired()
                    .HasColumnName("tipo_persona")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ubicaciones>(entity =>
            {
                entity.ToTable("ubicaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasColumnName("municipio")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Ubicaciones)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ubicaciones_departamentos");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordEncrypt)
                    .IsRequired()
                    .HasColumnName("password_encrypt")
                    .HasMaxLength(50);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
