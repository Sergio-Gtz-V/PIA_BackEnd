using PIA_BackEnd.Validations;
using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //[Phone]
        public string Phone { get; set; }

        public string Email { get; set; }

        public List<Raffle_Participant> Raffle_Participants { get; set; }

    }
}