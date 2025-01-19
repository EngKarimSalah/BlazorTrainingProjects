﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniAmazonSimulation.Data.Model
{
    public class ProductImages
    {
        [Key]
        public int imageId {  get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public Product product { get; set; } // Foreign key to Product

        public string imagePath { get; set; }
    }
}
