using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Proyecto_Grupal_PrograWeb2.Models
{
    public partial class ModeloSistema : DbContext
    {
        public ModeloSistema()
            : base("name=ModeloSistema")
        {
        }

        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<juego> juego { get; set; }
        public virtual DbSet<score> score { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin>()
                .Property(e => e.user)
                .IsUnicode(false);

            modelBuilder.Entity<admin>()
                .Property(e => e.contra)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.juego)
                .WithOptional(e => e.categoria)
                .HasForeignKey(e => e.categoria_id);

            modelBuilder.Entity<juego>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .HasMany(e => e.score)
                .WithOptional(e => e.juego)
                .HasForeignKey(e => e.juego_id);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.score)
                .WithOptional(e => e.usuario)
                .HasForeignKey(e => e.usuario_id);
        }
    }
}
