using System;
namespace back2Front.Models
{
    public class ProjetContact
    {

        public int ProjetId { get; set; }
        public Projet Projet { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public ProjetContact()
        {
        }
    }
}


