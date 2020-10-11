using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum Phones
{
    Bureau,
    MobilePro,
    MobilePerso
}

namespace back2Front.Models
{
    public class Telephone
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Numero { get; set; }

        public Phones PhoneType { get; set; }

        public virtual ICollection<Commentaire> Commentaires { get; set; }


        public Telephone()
        {
        }
    }
}
