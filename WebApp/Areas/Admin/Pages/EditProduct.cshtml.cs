using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;

namespace WebApp.Areas.Admin.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly ShopService _service = new();
        private readonly AdminService _admin = new();
        [BindProperty]
        public Products Product { get; set; }


        [BindProperty]
        public List<SelectListItem> Vendors { get; set; }

        [BindProperty]
        public List<SelectListItem> Categories { get; set; }

        [BindProperty]
        public List<SelectListItem> PriceDiscount { get; set; }


        public IActionResult OnGet(int? prodID)
        {
            #region Populate dropdown
            Vendors = _admin.GetVendorsQ().Select(v => new SelectListItem
            {
                Value = v.VendorID.ToString(),
                Text = v.Name
            }).ToList();

            Categories = _admin.GetCategoriesQ().Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.Category
            }).ToList();

            PriceDiscount = _admin.GetPriceDiscountsQ().Select(p => new SelectListItem
            {
                Value = p.PriceDiscountID.ToString(),
                Text = p.DiscountValue + " (" + p.DiscountCode + ")"
            }).ToList();
            #endregion
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.ProductID > 0)
            {
                _admin.Update(Product);
            }
            else
            {
                _admin.AddNew(Product);
            }
            _admin.Commit();
            return RedirectToPage("./Detail", new { prodID = Product.ProductID });
        }
    }
}
