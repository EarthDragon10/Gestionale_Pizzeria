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

        public virtual DbSet<Amministratori> Amministratori { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Prodotti> Prodotti { get; set; }
        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prodotti>()
                .Property(e => e.PrezzoVendita)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Prodotti>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.Prodotti)
                .WillCascadeOnDelete(false);
        }
    }
}
