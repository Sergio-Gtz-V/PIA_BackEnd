using PIA_BackEnd.Validations;
using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.Entities
{
    public class Raffle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(30)]
        [FirstLetterUppercase]
        public string Name { get; set; }
        [Required]
        public bool HasEnded { get; set; }
        [Required]
        [Range(1,54)]
        public int NumberOfWinners { get; set; }
        public List<Prizes> Prizes { get; set; }
        public List<Participant> Winners { get; set; }
        [Required]
        public int TicketPrice { get; set; }

        public List<Raffle_Participant> Raffle_Participants{ get; set; }
    }
}
