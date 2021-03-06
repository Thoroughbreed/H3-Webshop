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
    public class DetailModel : PageModel
    {
        private readonly IShopService _service;

        public Products Product { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IShopService shopService)
        {
            _service = shopService;
        }
        public void OnGet(int? prodID)
        {
            Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
        }
    }
}
