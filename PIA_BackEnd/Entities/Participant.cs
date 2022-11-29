using PIA_BackEnd.Validations;
using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [PhoneValidation]
        public string Phone { get; set; }

        public string Email { get; set; }

        public int CardId { get; set; }

    }
}