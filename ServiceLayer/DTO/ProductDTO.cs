using System;
using static System.Net.Mime.MediaTypeNames;

namespace ServiceLayer.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int ID { get; set; }
        public string SKU { get; set; }
        public byte[] Picture { get; set; }
    }
}