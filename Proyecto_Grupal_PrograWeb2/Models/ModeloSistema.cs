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

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<juego> juego { get; set; }
        public virtual DbSet<medalla> medalla { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<score> score { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.juego)
                .WithRequired(e => e.categoria)
                .HasForeignKey(e => e.categoria_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<juego>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<juego>()
                .HasMany(e => e.score)
                .WithRequired(e => e.juego)
                .HasForeignKey(e => e.juego_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<medalla>()
                .Property(e => e.nombre_medalla)
                .IsUnicode(false);

            modelBuilder.Entity<medalla>()
                .HasMany(e => e.score)
                .WithRequired(e => e.medalla)
                .HasForeignKey(e => e.medalla_id)
                .WillCascadeOnDelete(false);

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
                .WithRequired(e => e.usuario)
                .HasForeignKey(e => e.usuario_id)
                .WillCascadeOnDelete(false);
        }
    }
}
