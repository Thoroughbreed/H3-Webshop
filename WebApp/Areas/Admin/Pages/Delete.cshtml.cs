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
    public class DeleteModel : PageModel
    {
        private readonly AdminService _admin = new();
        [BindProperty]
        public Products Product { get; set; }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                Product = _admin.GetProductByID(id.Value);
            }
        }

        public IActionResult OnPost()
        {
            _admin.Delete(Product);
            return RedirectToPage("./Index");
        }
    }
}
