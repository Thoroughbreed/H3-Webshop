using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        [NotMapped]
        public decimal OrderSum { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid OrderGuid { get; set; }

        // Navigation properties
        public Customers Customer { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
