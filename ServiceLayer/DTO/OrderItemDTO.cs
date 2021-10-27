using System;
namespace ServiceLayer.DTO
{
    public class OrderItemDTO
    {
        public int id { get; set; }
        public int Product { get; set; }
        public int Amount { get; set; }
        public int CustomerID { get; set; }
        public decimal LinePrice { get; set; }
    }
}