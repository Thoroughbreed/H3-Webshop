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
    public class OrdersModel : PageModel
    {
        private readonly IAdminService _admin;
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public CustomerOrderOptions CustOrderOption { get; set; } = 0;
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        public List<Orders> Orders { get; set; }
        public OrdersModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public void OnGet()
        {
            PageCount = _admin.GetOrdersQ().Count();
            Orders = _admin.GetOrdersQ().ToList();
        }
    }
}
