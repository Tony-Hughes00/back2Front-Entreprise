using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class FacturationCategorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public FacturationCategorie()
        {
        }

        public enum enumFacuration
        {
            [Description("Devi")]
            Devi = 0,
            [Description("Facture")]
            Facture = 1
        }
        public static string GetTauxString(enumFacuration facturationType)
        {
            return ((enumFacuration)facturationType).ToString();
        }
    }
}
