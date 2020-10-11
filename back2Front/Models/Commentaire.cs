using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Commentaire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Gros titre doit comporter entre 3 et 50 caractères")]
        public string GrosTitre { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "")]
        public string ReviewText { get; set; }

        public Structure Structure { get; set; }

        public Contact Book { get; set; }

        public Commentaire()
        {
        }
    }
}
