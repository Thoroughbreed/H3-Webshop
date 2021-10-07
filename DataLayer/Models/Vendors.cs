using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Vendors
    {
        [Key]
        public int VendorID { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Products> Products { get; set; }
    }
}
