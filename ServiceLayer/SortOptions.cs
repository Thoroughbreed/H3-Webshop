using DataLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ServiceLayer
{
    public enum ProductOrderOptions
    {
        [Display(Name = "navn")]
        ByName = 0,
        [Display(Name = "producent")]
        ByVendor,
        [Display(Name = "pris stigende")]
        ByPriceAsc,
        [Display(Name = "pris faldende")]
        ByPriceDesc
    }

    public enum CustomerOrderOptions
    {
        [Display(Name = "fornavn")]
        ByFName = 0,
        [Display(Name = "efternavn")]
        ByLName,
        [Display(Name = "by")]
        ByCity,
        [Display(Name = "antal ordrer stigende")]
        ByOrdersAsc,
        [Display(Name = "antal ordrer faldende")]
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
                    return products.OrderBy(x => x.City.Name);
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
