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
    public class VendorsModel : PageModel
    {
        private readonly IAdminService _admin;

        public List<Vendors> Vendors { get; set; }
        public VendorsModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public void OnGet()
        {
            Vendors = _admin.GetVendorsQ().ToList();
        }
    }
}
