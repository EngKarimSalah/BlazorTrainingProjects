using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAmazonSimulation.Data.Model
{
    public class Product
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(50, ErrorMessage = "Product name cannot exceed 59 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }

       [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; } // Foreign key to Category

       [ForeignKey("seller")]
        public int SellerId { get; set; }
        public Seller seller { get; set; } // Foreign key to Seller

        public ICollection<ProductReview> ProductReviews { get; set; } // One-to-Many relationship



    }
}
