using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class OrderItems
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public decimal LinePrice { get; set; }

        // Navigation Properties
        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
