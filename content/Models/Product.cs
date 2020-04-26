using System;
using System.Collections.Generic;
using Vue2Spa.Areas.Portal.Models;

namespace HelpingHands.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }   
        public double Price { get; set; }
        public string Sku { get; set; }
        public string Upc { get; set; }  
        public string Mpn { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Diameter { get; set; }
        public int MinTolerance { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }
        public string Dimension { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public Guid Picture1Id { get; set; }
        public Guid Picture2Id { get; set; }
        public Guid Picture3Id { get; set; }
        public Guid Picture4Id { get; set; }
    }
}
