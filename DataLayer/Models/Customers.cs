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
        public string FName { get; set; }
        public string LName { get; set; }
        public string RoadName { get; set; }
        public int RoadNumber { get; set; }
        public int PostNumber { get; set; }
        public string PhoneMain { get; set; }
        public string ProneMobile { get; set; }
        public int OrderAmount { get; set; }

        // Navigation properties
        public Cities City { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
