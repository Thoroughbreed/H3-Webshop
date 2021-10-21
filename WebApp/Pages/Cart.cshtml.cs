using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer;

namespace WebApp.Pages
{
    public class CartModel : PageModel
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

        public IActionResult OnGetRemove(int id)
        {
            json = Request.Cookies["cart"];
            cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (cartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                var temp = cartCookie.FirstOrDefault(c => c.ProductID == id);
                cartCookie.Remove(temp);
            }

            json = JsonConvert.SerializeObject(cartCookie);
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetAdd(int id)
        {
            json = Request.Cookies["cart"];
            cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (cartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                CartOrderItems cartItem = cartCookie.First(c => c.ProductID == id);
                cartItem.Amount++;
            }

            json = JsonConvert.SerializeObject(cartCookie);
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetSub(int id)
        {
            json = Request.Cookies["cart"];
            cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (cartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                CartOrderItems cartItem = cartCookie.First(c => c.ProductID == id);
                if (cartItem.Amount == 1)
                {
                    var temp = cartCookie.FirstOrDefault(c => c.ProductID == id);
                    cartCookie.Remove(temp);
                }
                cartItem.Amount--;
            }

            json = JsonConvert.SerializeObject(cartCookie);
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetEmpty()
        {
            Response.Cookies.Delete("cart");
            return RedirectToPage("Cart");
        }
    }
}