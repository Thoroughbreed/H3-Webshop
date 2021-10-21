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
    public class NewCatModel : PageModel
    {
        private readonly IAdminService _admin;

        [BindProperty(SupportsGet = true)]
        public Categories Category { get; set; }

        public NewCatModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Category = _admin.GetCategoriesQ().Where(c => c.CategoryID == id.Value).FirstOrDefault();
            }
            else
            {
                Category = new Categories();
            }
            if (Category == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Category.CategoryID > 0)
            {
                _admin.Update(Category);
            }
            else
            {
                _admin.AddNew(Category);
            }
            _admin.Commit();
            TempData["Message"] = "Kategori opdateret!";
            return RedirectToPage("./Categories");
        }
    }
}
