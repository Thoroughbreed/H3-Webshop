using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class PriceDiscounts
    {
        [Key]
        public int PriceDiscountID { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountValue { get; set; }

        // Navigation Property
        public ICollection<Products> Products { get; set; }
    }
}
