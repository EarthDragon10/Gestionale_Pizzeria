using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Gestionale_Pizzeria.Models
{
    public partial class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<DettagliOrdine> DettagliOrdine { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Ruoli> Ruoli { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DettagliOrdine>()
                .HasOptional(e => e.Ordini)
                .WithRequired(e => e.DettagliOrdine);

            modelBuilder.Entity<Ordini>()
                .Property(e => e.Importo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prodotti>()
                .Property(e => e.PrezzoVendita)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.DettagliOrdine)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ruoli>()
                .HasMany(e => e.Utenti)
                .WithRequired(e => e.Ruoli)
                .HasForeignKey(e => e.IdRuolo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasOptional(e => e.Ordini)
                .WithRequired(e => e.Utenti);
        }
    }
}
