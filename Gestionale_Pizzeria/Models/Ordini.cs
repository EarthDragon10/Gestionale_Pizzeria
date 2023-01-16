namespace Gestionale_Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [Key]
        public int IdOrdine { get; set; }

        public int IdProdotto { get; set; }

        public int Quantita { get; set; }

        public int IdUtente { get; set; }

        public int Prezzo { get; set; }

        [Required]
        public string Indirizzo { get; set; }

        public string Nota { get; set; }

        public bool? Evaso { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
