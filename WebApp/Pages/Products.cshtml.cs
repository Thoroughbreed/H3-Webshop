using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ShopService _service = new();

        // Ordering and search
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public ProductOrderOptions prodOrderOption { get; set; } = 0;

        // Pagination
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        // Model properties
        [TempData]
        public string Message { get; set; }
        public List<Products> Products { get; set; }

        public void OnGet()
        {
            PageCount = _service.GetProductsQ(Search).Count();
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);
        }

        public IActionResult OnGetCart(string name)
        {
            PageCount = _service.GetProductsQ(Search).Count();
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);
            TempData["Message"] = name;
            return RedirectToPage("Products");
        }
    }
}