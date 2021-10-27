using System;
using System.Linq;
using DataLayer.Models;
using ServiceLayer.DTO;
using ServiceLayer;

namespace ServiceLayer
{
    public static class DTOMapHelper
    {
        public static ProductDTO ToDto(this Products product)
        {
            string vnd = "";
            if (product.Vendor != null)
            {
                vnd = product.Vendor.Name;
            }
            return new ProductDTO
            {
                Name = product.Name,
                Vendor = vnd,
                Category = product.Category.Category,
                Price = product.Price,
                ID = product.ProductID
            };
        }

        public static IQueryable<ProductDTO> ConvertToDTO(this IQueryable<Products> product)
        {
            return product.Select(p => p.ToDto());
        }

        public static CustomerDTO ToDto(this Customers customer)
        {
            return new CustomerDTO
            {
                Name = customer.FName + ' ' + customer.LName,
                Address = customer.RoadName + ' ' + customer.RoadNumber,
                City = customer.PostNumber.ToString() + ' ' + customer.City.Name,
                Orders = customer.OrderAmount.Value,
                id = customer.CustomerID,
                EMail = customer.EMail
            };
        }

        public static IQueryable<CustomerDTO> ConvertToDTO(this IQueryable<Customers> customer)
        {
            return customer.Select(c => c.ToDto());
        }

        public static OrderItemDTO ToDTO(this OrderItems item)
        {
            return new OrderItemDTO
            {
                Product = item.ProductID,
                Amount = item.Amount,
                id = item.OrderID,
                LinePrice = item.LinePrice
            };
        }

        public static OrderDTO ToDto(this Orders order)
        {
            return new OrderDTO
            {
                OrderID = order.OrderGuid.ToString().Substring(0, 8),
                Customer = order.Customer.ToDto(),
                Items = order.OrderItems.Select(o => o.ToDTO()).ToList()
            };
        }

        public static IQueryable<OrderDTO> ConvertToDTO(this IQueryable<Orders> order)
        {
            return order.Select(o => o.ToDto());
        }
    }
}