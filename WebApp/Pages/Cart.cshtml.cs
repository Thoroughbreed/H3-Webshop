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
        private readonly IShopService _service;
        public CartModel(IShopService shopService)
        {
            _service = shopService;
        }
        public List<OrderItems> Cart { get; } = new List<OrderItems>();
        private List<CartOrderItems> CartCookie { get; set; }
        public List<Products> Products { get; } = new List<Products>();
        public Orders Order { get; set; }
        public Customers Customer { get; set; }
        public string json { get; private set; }
        public void OnGet()
        {
            json = Request.Cookies["cart"];
            if (!string.IsNullOrWhiteSpace(json))
            {
                CartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
                foreach (var item in CartCookie)
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
            CartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (CartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                var temp = CartCookie.FirstOrDefault(c => c.ProductID == id);
                CartCookie.Remove(temp);
            }

            json = JsonConvert.SerializeObject(CartCookie);
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetAdd(int id)
        {
            json = Request.Cookies["cart"];
            CartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (CartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                CartOrderItems cartItem = CartCookie.First(c => c.ProductID == id);
                cartItem.Amount++;
            }

            json = JsonConvert.SerializeObject(CartCookie);
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS

            return RedirectToPage("Cart");
        }

        public IActionResult OnGetSub(int id)
        {
            json = Request.Cookies["cart"];
            CartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
            if (CartCookie.FirstOrDefault(c => c.ProductID == id) != null)
            {
                CartOrderItems cartItem = CartCookie.First(c => c.ProductID == id);
                if (cartItem.Amount == 1)
                {
                    var temp = CartCookie.FirstOrDefault(c => c.ProductID == id);
                    CartCookie.Remove(temp);
                }
                cartItem.Amount--;
            }

            json = JsonConvert.SerializeObject(CartCookie);
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