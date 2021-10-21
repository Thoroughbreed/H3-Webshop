using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Areas.Admin.Pages
{
    public class OrderDetailModel : PageModel
    {
        private readonly IAdminService _admin;
        public Orders Order { get; set; }
        public OrderDetailModel(IAdminService adminService)
        {
            _admin = adminService;
        }
        public void OnGet(string guid)
        {
            Order = _admin.GetOrdersByGUID(guid);
        }
    }
}
