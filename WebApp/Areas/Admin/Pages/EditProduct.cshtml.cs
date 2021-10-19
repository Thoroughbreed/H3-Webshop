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
    public class EditProductModel : PageModel
    {
        private readonly ShopService _service = new ShopService();
        [BindProperty]
        public Products Product { get; set; }
        public IActionResult OnGet(int? prodID)
        {
            if (prodID.HasValue)
            {
                Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
            }
            else
            {
                Product = new Products();
            }


            if (Product == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
