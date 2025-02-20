using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTO
{
    public class RegisterUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "The field must be exactly 11 digits.")]
        public string PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
