﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAmazonSimulation.Data.Model
{
    public class ProductReview
    {
        [Key]
        public int RId { get; set; }

        [Required(ErrorMessage = "Review content is required.")]
        public string ReviewContent { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public Product product { get; set; } // Foreign key to Product

        [ForeignKey("client")]
        public int ClientId { get; set; }
        public Client client { get; set; } // Foreign key to Client
    }
}
