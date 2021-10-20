using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CartModel : PageModel
    {
        public List<OrderItems> Cart { get; set; }
        public Products Product { get; set; }
        public Orders Order { get; set; }
        public Customers Customer { get; set; }
        public void OnGet()
        {

        }
    }
}