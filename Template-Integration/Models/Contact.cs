using System.ComponentModel.DataAnnotations;

namespace Template_Integration.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        [Required]
        public required string DateOfBirth { get; set; }

        [Required]
        public required string Clinic { get; set; }

        [Required]
        public required string Docter { get; set; }

        [Required]
        public required string Message { get; set; }
    }
}