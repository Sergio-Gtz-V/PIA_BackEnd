namespace PIA_BackEnd.Entities
{
    public class Raffle_Participant
    {
        public int Id { get; set; }

        public int RaffleId { get; set; }

        public int CardId { get; set; }

        public Raffle Raffle { get; set; }

        public int ParticipantId { get; set; }

        public Participant Participant { get; set; }
    }
}
