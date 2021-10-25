using System;
using System.Linq;
using DataLayer.Models;
using ServiceLayer.DTO;

namespace ServiceLayer
{
    public static class DTOMapHelper
    {
        public static ProductDTO ToDto(this Products product)
        {
            return new ProductDTO
            {
                Name = product.Name,
                Vendor = product.Vendor.Name,
                Category = product.Category.Category,
                Price = product.Price
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
                Address = customer.RoadName + ' ' + customer.RoadNumber + '\n' + customer.PostNumber + ' ' + customer.City.Name,
                Orders = customer.OrderAmount.Value
            };
        }

        public static IQueryable<CustomerDTO> ConvertToDTO(this IQueryable<Customers> customer)
        {
            return customer.Select(c => c.ToDto());
        }
    }
}