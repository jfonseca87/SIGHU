namespace SIGHU.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SIGHUContext : DbContext
    {
        public SIGHUContext()
            : base("name=SIGHUContext")
        {
            this.Configuration.LazyLoadingEnabled = false; 
        }

        public virtual DbSet<ADJUNTOS> ADJUNTOS { get; set; }
        public virtual DbSet<ARMA> ARMA { get; set; }
        public virtual DbSet<CARGO> CARGO { get; set; }
        public virtual DbSet<EMPRESA> EMPRESA { get; set; }
        public virtual DbSet<GRUPO_ADJUNTO> GRUPO_ADJUNTO { get; set; }
        public virtual DbSet<PERFILES> PERFILES { get; set; }
        public virtual DbSet<PERSONA> PERSONA { get; set; }
        public virtual DbSet<PERSONA_HAS_CARGO> PERSONA_HAS_CARGO { get; set; }
        public virtual DbSet<TIPO_ADJUNTO> TIPO_ADJUNTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<VEHICULO> VEHICULO { get; set; }
        public virtual DbSet<VESTUARIO> VESTUARIO { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            modelBuilder.Entity<GRUPO_ADJUNTO>()
                .HasMany(e => e.TIPO_ADJUNTO)
                .WithOptional(e => e.GRUPO_ADJUNTO)
                .HasForeignKey(e => e.IdGrupo);

            modelBuilder.Entity<PERSONA>()
                .HasMany(e => e.USUARIO)
                .WithOptional(e => e.PERSONA)
                .HasForeignKey(e => e.IdPersona);

            modelBuilder.Entity<PERSONA>()
               .HasMany(e => e.ADJUNTOS)
               .WithOptional(e => e.PERSONA)
               .HasForeignKey(e => e.IdPersona);

            modelBuilder.Entity<PERSONA>()
               .HasMany(e => e.PERSONA_HAS_CARGO)
               .WithOptional(e => e.PERSONA)
               .HasForeignKey(e => e.IdPersona);

            modelBuilder.Entity<PERFILES>()
                .HasMany(e => e.USUARIO)
                .WithOptional(e => e.PERFILES)
                .HasForeignKey(e => e.IdPerfil);

            modelBuilder.Entity<TIPO_ADJUNTO>()
               .HasMany(e => e.ADJUNTOS)
               .WithRequired(e => e.TIPO_ADJUNTO)
               .HasForeignKey(e => e.IdTipoAdjunto)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<CARGO>()
                .HasMany(e => e.PERSONA_HAS_CARGO)
                .WithOptional(e => e.CARGO)
                .HasForeignKey(e => e.IdCargo);

            modelBuilder.Entity<ARMA>()
               .HasMany(e => e.PERSONA_HAS_CARGO)
               .WithOptional(e => e.ARMA)
               .HasForeignKey(e => e.IdArma);

            modelBuilder.Entity<VESTUARIO>()
               .HasMany(e => e.PERSONA_HAS_CARGO)
               .WithOptional(e => e.VESTUARIO)
               .HasForeignKey(e => e.IdVestuario);

            modelBuilder.Entity<VEHICULO>()
               .HasMany(e => e.PERSONA_HAS_CARGO)
               .WithOptional(e => e.VEHICULO)
               .HasForeignKey(e => e.IdVehiculo);

            modelBuilder.Entity<EMPRESA>()
               .HasMany(e => e.PERSONA_HAS_CARGO)
               .WithOptional(e => e.EMPRESA)
               .HasForeignKey(e => e.IdEmpresa);
        }
    }
}
