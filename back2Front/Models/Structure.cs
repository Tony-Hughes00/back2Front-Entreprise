using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Structure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public virtual ICollection<Secteur> Secteurs { get; set; }

        public virtual ICollection<StructureContact> Contacts { get; set; }

        public virtual ICollection<Projet> Projets { get; set; }

        public virtual ICollection<Adresse> Adresses { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }


        public Structure()
        {
        }
    }

}
