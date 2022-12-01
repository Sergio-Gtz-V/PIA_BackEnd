using System.ComponentModel.DataAnnotations;

namespace PIA_BackEnd.DTOs
{
    public class EditAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
