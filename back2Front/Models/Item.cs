using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public decimal PrixUnitaire { get; set; }

        public decimal Taux;

        public DateTime DateLivraison { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public Item()
        {
        }
    }
}
