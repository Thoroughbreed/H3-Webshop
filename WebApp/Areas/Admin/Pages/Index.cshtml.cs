using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public List<Customers> Customers { get; set; }
        public List<Products> Products { get; set; }

        public void OnGet(string? queryString)
        {
            Customers = _service.GetCustomersQ().ToList();
            Products = _service.GetProductsQ(queryString).ToList();
        }
    }
}
