using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Agenda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public DateTime Debut { get; set; }

        public DateTime Fin { get; set; }

        public AgendaCategorie Categorie { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public Agenda()
        {
        }
    }
}
