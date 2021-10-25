using System;
namespace ServiceLayer.DTO
{
    public class OrderItemDTO
    {
        public int id { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
    }
}
