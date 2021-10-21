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
    public class NewDiscountModel : PageModel
    {
        private readonly IAdminService _admin;
        [BindProperty(SupportsGet = true)]
        public PriceDiscounts Discount { get; set; }

        public NewDiscountModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Discount = _admin.GetPriceDiscountsQ().Where(d => d.PriceDiscountID == id.Value).FirstOrDefault();
            }
            else
            {
                Discount = new PriceDiscounts();
            }
            if (Discount == null)
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
            if (Discount.PriceDiscountID > 0)
            {
                _admin.Update(Discount);
            }
            else
            {
                _admin.AddNew(Discount);
            }
            _admin.Commit();
            TempData["Message"] = "Rabatkode opdateret!";
            return RedirectToPage("./Discounts");
        }
    }
}
