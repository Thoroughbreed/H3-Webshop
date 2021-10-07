using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public int PriceDiscountID { get; set; }
        public int CategoryID { get; set; }
        public int VendorID { get; set; }

        // Navigation properties
        public Vendors Vendor { get; set; }
        public Categories Category { get; set; }
        public PriceDiscounts PriceDiscount { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
