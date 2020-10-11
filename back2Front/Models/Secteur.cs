using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Secteur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Nom ne peut pas contenir plus de 100 caractères")]
        public string Nom { get; set; }

        public virtual ICollection<Adresse> Adresses{ get; set; }

        public string email { get; set; }

        public virtual ICollection<Telephone> Telephones { get; set; }

        public Secteur()
        {
        }
    }
}
