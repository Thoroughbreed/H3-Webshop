using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Cities
    {
        [Key]
        public int PostNumber { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Customers> Customer { get; set; }
    }
}
