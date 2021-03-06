using System;
using System.Collections.Generic;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Areas.Admin.Pages
{
    public class CustomerInfoModel : PageModel
    {
        private readonly IAdminService _admin;

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public CustomerOrderOptions CustOrderOption { get; set; } = 0;
        [TempData]
        public string Message { get; set; }


        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        public List<Customers> Customers { get; set; }

        public CustomerInfoModel(IAdminService adminService)
        {
            _admin = adminService;
        }

        public void OnGet()
        {
            Customers = _admin.GetCustomers(CurrPage, PageSize, CustOrderOption, Search);
        }
    }
}
