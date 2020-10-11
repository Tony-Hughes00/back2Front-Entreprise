using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Titre ne peut pas contenir plus de 100 caractères")]
        public string Titre { get; set; }

        [MaxLength(100, ErrorMessage = "Titre ne peut pas contenir plus de 100 caractères")]
        public string Civlite { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Prenom ne peut pas contenir plus de 100 caractères")]
        public string Prenom { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public virtual ICollection<StructureContact> Structures { get; set; }

        public virtual ICollection<ProjetContact> Projets { get; set; }

        public Contact()
        {
        }
    }
}
