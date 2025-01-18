using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAmazonSimulation.Data.Model
{
    public class Seller
    {
        [Key]
        public int SId { get; set; }
 
        [ForeignKey("user")]
        public int UserId { get; set; }
        public User user { get; set; } // One-to-One relationship with User

        public int SellerRating { get; set; }
    }
}
