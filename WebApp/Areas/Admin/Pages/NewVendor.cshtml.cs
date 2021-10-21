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
    public class NewVendorModel : PageModel
    {
        private readonly IAdminService _admin;
        [BindProperty(SupportsGet = true)]
        public Vendors Vendor { get; set; }
        public NewVendorModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Vendor = _admin.GetVendorsQ().Where(d => d.VendorID == id.Value).FirstOrDefault();
            }
            else
            {
                Vendor = new Vendors();
            }
            if (Vendor == null)
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
            if (Vendor.VendorID > 0)
            {
                _admin.Update(Vendor);
            }
            else
            {
                _admin.AddNew(Vendor);
            }
            _admin.Commit();
            TempData["Message"] = "Producent opdateret!";
            return RedirectToPage("./Discounts");
        }

    }
}
