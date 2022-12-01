using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.Entities
{
    public class Raffle_Participant
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int RaffleId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int CardId { get; set; }

  
        public Raffle Raffle { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ParticipantId { get; set; }

        public Participant Participant { get; set; }
    }
}
