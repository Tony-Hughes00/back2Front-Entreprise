using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class Taux {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        public enum enumTaux
        {
            [Description("TVA non applicable, art. 293 B du CGI")]
            TVAnonApplicable = 0
        }
        public static string GetTauxString(enumTaux taux)
        {
            return ((enumTaux)taux).ToString();
        }
    }

}