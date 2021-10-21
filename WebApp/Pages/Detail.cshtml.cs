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
    public class DetailModel : PageModel
    {
        private readonly ShopService _service = new();
        [TempData]
        public string Message { get; set; }
        public Products Product { get; set; }
        public void OnGet(int? prodID)
        {
            Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
        }
        public IActionResult OnGetCart(string name, int? prodID)
        {
            Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
            TempData["Message"] = name;
            return RedirectToPage("Detail", new { prodID = prodID.Value });
        }
    }
}
