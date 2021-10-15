using DataLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceLayer
{
    public enum ProductOrderOptions
    {
        [Display(Name = "Sort by name ↓")]
        ByName = 0,
        [Display(Name = "Sort by category ↓")]
        ByCategory,
        [Display(Name = "Sort by vendor ↓")]
        ByVendor,
        [Display(Name = "Price ↓")]
        ByPriceAsc,
        [Display(Name = "Price ↑")]
        ByPriceDesc
    }

    public enum CustomerOrderOptions
    {
        [Display(Name = "Sort by first name ↓")]
        ByFName = 0,
        [Display(Name = "Sort by last name ↓")]
        ByLName,
        [Display(Name = "Sort by city ↓")]
        ByCity,
        [Display(Name = "Sort by orders ↓")]
        ByOrdersAsc,
        [Display(Name = "Sort by orders ↑")]
        ByOrdersDesc
    }
    public static class SortOptions
    {
        public static IQueryable<Products> OrderByOptions(this IQueryable<Products> products, ProductOrderOptions orderOptions)
        {
            switch (orderOptions)
            {
                case ProductOrderOptions.ByName:
                    return products.OrderBy(x => x.Name);
                case ProductOrderOptions.ByPriceAsc:
                    return products.OrderBy(x => x.Price);
                case ProductOrderOptions.ByPriceDesc:
                    return products.OrderByDescending(x => x.Price);
                case ProductOrderOptions.ByCategory:
                    return products.OrderBy(x => x.Category.Category);
                case ProductOrderOptions.ByVendor:
                    return products.OrderBy(x => x.Vendor.Name);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderOptions), orderOptions, null);
            }
        }
        public static IQueryable<Customers> OrderByOptions(this IQueryable<Customers> products, CustomerOrderOptions orderOptions)
        {
            switch (orderOptions)
            {
                case CustomerOrderOptions.ByFName:
                    return products.OrderBy(x => x.FName);
                case CustomerOrderOptions.ByLName:
                    return products.OrderBy(x => x.LName);
                case CustomerOrderOptions.ByCity:
                    return products.OrderByDescending(x => x.City.Name);
                case CustomerOrderOptions.ByOrdersAsc:
                    return products.OrderBy(x => x.OrderAmount);
                case CustomerOrderOptions.ByOrdersDesc:
                    return products.OrderByDescending(x => x.OrderAmount);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderOptions), orderOptions, null);
            }
        }
    }
}
