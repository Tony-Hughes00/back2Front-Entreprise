using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using back2Front.Services;

namespace back2Front.Models
{
    public class Depense
    {
        public Depense()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public DepenseCategorie.enumDepense Categorie { get; set; }

        public decimal Montant { get; set; }

        public Taux.enumTaux Taux { get; set; }

        public DateTime Date { get; set; }

        public Structure Structure { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }


    }
}
