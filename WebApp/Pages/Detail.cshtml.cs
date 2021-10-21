using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer;

namespace WebApp.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ShopService _service = new();
        [TempData]
        public string Message { get; set; }
        public Products Product { get; set; }
        public void OnGet(int? prodID)
        {
            Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
        }
        public IActionResult OnGetCart(string name, int? prodID)
        {
            Product = _service.GetProductByIDQ(prodID.Value).FirstOrDefault();
            TempData["Message"] = name;

            #region Cart Cookie dims
            string json;
            if (Request.Cookies.ContainsKey("cart"))
            {
                json = Request.Cookies["cart"];
                List<CartOrderItems> cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
                if (cartCookie.FirstOrDefault(c => c.ProductID == prodID) != null)
                {
                    CartOrderItems cartItem = cartCookie.First(c => c.ProductID == prodID);
                    cartItem.Amount++;
                }
                else
                {
                    CartOrderItems newCartItem = new() { ProductID = Product.ProductID, Amount = 1 };
                    cartCookie.Add(newCartItem);
                }

                json = JsonConvert.SerializeObject(cartCookie);
            }
            else
            {
                List<CartOrderItems> cartCookie = new();
                CartOrderItems cartItem = new() { ProductID = Product.ProductID, Amount = 1 } ;
                cartCookie.Add(cartItem);

                json = JsonConvert.SerializeObject(cartCookie);

            }
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS
            #endregion

            return RedirectToPage("Detail", new { prodID = prodID.Value });
        }
    }
}
