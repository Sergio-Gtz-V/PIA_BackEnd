using System.ComponentModel.DataAnnotations;


namespace PIA_BackEnd.DTO

{
    public class ParticipantDTO
    {
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
    }
}
