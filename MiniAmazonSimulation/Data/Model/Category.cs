using System.ComponentModel.DataAnnotations;

namespace MiniAmazonSimulation.Data.Model
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(12, ErrorMessage = "Category name cannot exceed 12 characters.")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } // One-to-Many relationship
    }
}
