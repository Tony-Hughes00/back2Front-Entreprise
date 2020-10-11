using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Projet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public virtual ICollection<Facturation> Facturations { get; set; }

        public virtual ICollection<Depense> Depenses { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public virtual ICollection<ProjetContact> Contacts { get; set; }

        public Projet()
        {
        }
    }
}
