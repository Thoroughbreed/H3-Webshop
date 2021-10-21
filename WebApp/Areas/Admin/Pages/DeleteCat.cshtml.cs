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
    public class DeleteCatModel : PageModel
    {
        private readonly AdminService _admin = new();
        [BindProperty]
        public Categories Category { get; set; }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                Category = _admin.GetCategoriesQ().Where(c => c.CategoryID == id.Value).FirstOrDefault();
            }
        }

        public IActionResult OnPost(int id)
        {
            Category = _admin.GetCategoriesQ().Where(c => c.CategoryID == id).FirstOrDefault();
            _admin.Delete(Category);
            _admin.Commit();
            TempData["Message"] = $"Produkt slettet ... du har altså slettet {Category.Category}!";
            return RedirectToPage("./Index");
        }

    }
}
