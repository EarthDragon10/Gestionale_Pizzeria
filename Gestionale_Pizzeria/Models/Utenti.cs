namespace Gestionale_Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Utenti")]
    public partial class Utenti
    {
        [Key]
        public int IdUtente { get; set; }

        [Required(ErrorMessage = "Username sbagliato!")]
        [StringLength(20)]       
        public string Username { get; set; }

        [Required(ErrorMessage = "Password sbagliato!")]
        [StringLength(20)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Cognome { get; set; }

        [Display(Name ="Ruolo")]
        public int IdRuolo { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Ruoli Ruoli { get; set; }
    }
}
