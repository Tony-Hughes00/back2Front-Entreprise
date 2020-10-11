using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class DepenseCategorie
    {
        public enum enumDepense
        {
            [Description("Assurance")]
            Assurance = 0,
            [Description("Hébergement")]
            Hebergement = 1
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DepenseCategorie()
        {
        }
        public static string GetDepenseString(enumDepense depense)
        {
            return ((enumDepense)depense).ToString();
        }
    }
}
