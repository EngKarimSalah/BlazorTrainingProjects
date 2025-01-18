using System.ComponentModel.DataAnnotations;

namespace MiniAmazonSimulation.Data.Model
{
    public class User
    {
        [Key]
        public int UId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password cannot be less than 8 characters.")]
        public string Password { get; set; }

        public string Country { get; set; }

        public string Role { get; set; } // "Seller" or "Client"

    }
}
