using System;

namespace back2Front.Models
{
    public class StructureContact
    {
        public int StructureId { get; set; }
        public Structure Structure { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public StructureContact()
        {
        }
    }
}
