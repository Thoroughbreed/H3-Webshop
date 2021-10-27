using System;
using System.Collections.Generic;
using DataLayer.Models;

namespace ServiceLayer.DTO
{
    public class OrderDTO
    {
        public string OrderID { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}