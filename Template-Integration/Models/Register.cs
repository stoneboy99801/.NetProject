using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template_Integration.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password", ErrorMessage = "Password or confirmed are not matched.")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } = "User";
    }
}
