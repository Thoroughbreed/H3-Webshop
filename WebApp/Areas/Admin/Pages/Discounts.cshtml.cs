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
    public class DiscountsModel : PageModel
    {
        private readonly IAdminService _admin;

        public List<PriceDiscounts> Discounts { get; set; }
        public DiscountsModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public void OnGet()
        {
            Discounts = _admin.GetPriceDiscountsQ().ToList();
        }
    }
}
