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


        public SelectList Vendors { get; set; }
        public SelectList Categories { get; set; }
        public SelectList PriceDiscount { get; set; }
        public List<Vendors> VendorList { get; set; }


        public IActionResult OnGet(int? prodID)
        {
            VendorList = _admin.GetVendorsQ().ToList();
            Vendors = new SelectList(VendorList);

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
