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
    public class CheckoutModel : PageModel
    {
        private readonly ShopService _service = new();
        public List<OrderItems> Cart { get; set; } = new();
        public List<CartOrderItems> cartCookie { get; set; }
        public List<Products> Products { get; set; } = new();
        public Orders Order { get; set; }
        public Customers Customer { get; set; }
        public string json { get; set; }




        public void OnGet()
        {
            json = Request.Cookies["cart"];
            if (!string.IsNullOrWhiteSpace(json))
            {
                cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
                foreach (var item in cartCookie)
                {
                    var prod = _service.GetProductByIDQ(item.ProductID).FirstOrDefault();
                    Products.Add(prod);
                    Cart.Add(new OrderItems { ProductID = item.ProductID, Amount = item.Amount, LinePrice = prod.Price * item.Amount });
                }
            }
        }
    }
}
