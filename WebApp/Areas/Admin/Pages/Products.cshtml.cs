using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Areas.Admin.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IShopService _service;
        private readonly IAdminService _admin;

        public ProductsModel(IShopService service, IAdminService admin)
        {
            _service = service;
            _admin = admin;
        }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public ProductOrderOptions prodOrderOption { get; set; } = 0;
        [TempData]
        public string Message { get; set; }


        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        public List<Products> Products { get; set; }

        public void OnGet()
        {
            PageCount = _service.GetProductsQ(Search).Count();
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);

        }
    }
}
