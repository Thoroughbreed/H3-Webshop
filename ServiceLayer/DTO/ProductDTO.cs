using System;
namespace ServiceLayer.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int ID { get; set; }
    }
}