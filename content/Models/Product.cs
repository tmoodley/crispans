using System;

namespace HelpingHands.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }   
        public double Price { get; set; }
        public string Upc { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Diameter { get; set; }
        public int MinTolerance { get; set; }
        public string CustomerId { get; set; }
        public Customer Customers { get; set; }
    }
}
