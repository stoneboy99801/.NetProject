using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template_Integration.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [Required]
        public decimal DiscountedPrice { get; set; }

        [Required]
        public string ProductImage { get; set; }

        [NotMapped]
        public IFormFile? ProductImageFile { get; set; }
    }
}
