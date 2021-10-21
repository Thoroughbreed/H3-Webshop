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
    public class CategoriesModel : PageModel
    {
        private readonly IAdminService _admin;

        public List<Categories> Cats { get; set; }
        public CategoriesModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public void OnGet()
        {
            Cats = _admin.GetCategoriesQ().ToList();
        }
    }
}
