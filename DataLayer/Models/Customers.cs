using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string EMail { get; set; }
//        [Required]
        public string Password { get; set; }
        public string RoadName { get; set; }
        public string RoadNumber { get; set; }
        public int PostNumber { get; set; }
        public string PhoneMain { get; set; }
        public string PhoneMobile { get; set; }
        public int? OrderAmount { get; set; }

        // Navigation properties
        public Cities City { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
