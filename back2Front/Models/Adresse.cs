using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Adresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string rue { get; set; }

        public string nombre { get; set; }

        public string complement { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }

        public Adresse()
        {
        }
    }
}
