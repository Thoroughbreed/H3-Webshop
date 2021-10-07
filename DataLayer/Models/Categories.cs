using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string Category { get; set; }

        // Navigation Property
        public ICollection<Products> Products { get; set; }
    }
}
