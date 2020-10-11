using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back2Front.Models
{
    public class AgendaCategorie
    {
        public enum enumAgendaCategorie
        {
            [Description("Date de livraison prévue")]
            DateLivraison = 0,
            [Description("Paiement à la signature")]
            PaiementSignature = 1,
            [Description("Paiement à la livraison")]
            PaiementLivraison = 2,
            [Description("Paiement intermédiaire")]
            PaiementIntemediaire = 3,
            [Description("Paiement reçu")]
            PaiementReçu = 4
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public AgendaCategorie()
        {
        }

        public static string GetTauxString(enumAgendaCategorie agendaCategorie)
        {
            return ((enumAgendaCategorie)agendaCategorie).ToString();
        }

    }
}
