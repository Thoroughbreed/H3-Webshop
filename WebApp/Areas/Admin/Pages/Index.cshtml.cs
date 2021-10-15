using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Areas.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ShopService _service = new();
        private readonly AdminService _admin = new();

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public ProductOrderOptions prodOrderOption { get; set; } = 0;
        public CustomerOrderOptions custOrderOption { get; set; } = 0;

        public int PageCount { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));


        public List<Customers> Customers { get; set; }
        public List<Products> Products { get; set; }

        public void OnGet()
        {
            PageCount   = _admin.GetCustomersQ(Search).Count();
            PageCount  += _service.GetProductsQ(Search).Count();
            //Customers   = _admin.GetCustomersQ(Search).ToList();
            //Products    = _service.GetProductsQ(Search).ToList();
            Customers = _admin.GetCustomers(CurrPage, PageSize, custOrderOption, Search);
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);
        }
    }
}
