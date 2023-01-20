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

        [Column(TypeName = "date")]
        public DateTime DataOrdine { get; set; }

        [Column(TypeName = "money")]
        public decimal Importo { get; set; }

        //[Required]
        [StringLength(20)]
        public string StatoOrdine { get; set; }

        //[Required]
        public string Confermato { get; set; }

        public bool Evaso { get; set; }

        public int IdDettaglioOrdine { get; set; }

        public int IdUtente { get; set; }

        public virtual DettagliOrdine DettagliOrdine { get; set; }

        public virtual Utenti Utenti { get; set; }
        [NotMapped()]
        public virtual Prodotti Prodotti { get; set; }
    }
}
