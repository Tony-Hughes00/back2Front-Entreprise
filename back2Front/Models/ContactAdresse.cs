using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class ContactAdresse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ContactId { get; set; }
        public Structure Contact { get; set; }

        public int AdresseId { get; set; }
        public Adresse Adrresse { get; set; }

        public ContactAdresse()
        {
        }
    }
}
