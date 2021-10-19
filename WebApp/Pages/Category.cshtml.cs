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
    public class CategoryModel : PageModel
    {
        private readonly ShopService _service = new();
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public Categories Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public ProductOrderOptions prodOrderOption { get; set; } = 0;
        [TempData]
        public string Message { get; set; }


        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        public List<Products> Products { get; set; }
        public void OnGet(int catID)
        {
            Category = _service.GetCategoryByIDQ(catID).FirstOrDefault();
            PageCount = _service.GetProductsQ(Search).Where(p => p.CategoryID == catID).Count();
            Products = _service.GetProductsByCat(CurrPage, PageSize, catID, prodOrderOption, Search).ToList();
        }
    }
}
