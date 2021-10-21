using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer;

namespace WebApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly ShopService _service = new();

        public List<OrderItems> Cart { get; set; }
        public List<CartOrderItems> cartCookie { get; set; }
        public List<Products> Products { get; set; } = new();
        public Orders Order { get; set; }
        public Customers Customer { get; set; }
        public void OnGet()
        {
            string json = Request.Cookies["cart"];
            cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            foreach (var item in cartCookie)
            {
                Products.Add(_service.GetProductByIDQ(item.ProductID).FirstOrDefault());
            }
        }
    }
}