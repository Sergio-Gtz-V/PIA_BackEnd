﻿using PIA_BackEnd.Validations;
using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.Entities
{
    public class Participant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo {0} solo puede tener hasta 150 caracteres")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public List<Raffle_Participant> Raffle_Participants { get; set; }

    }
}