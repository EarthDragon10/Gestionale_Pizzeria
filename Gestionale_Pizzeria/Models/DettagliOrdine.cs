namespace Gestionale_Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettagliOrdine")]
    public partial class DettagliOrdine
    {
        [Key]
        public int IdDettaglioOrdine { get; set; }

        public int quantita { get; set; }

        [Required]
        public string nota { get; set; }

        public int? IdProdotto { get; set; }

        public int? IdOrdine { get; set; }

        public virtual Prodotti Prodotti { get; set; }

        public virtual Ordini Ordini { get; set; }
    }
}
