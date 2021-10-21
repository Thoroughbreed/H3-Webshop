using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer;

namespace WebApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ShopService _service = new();

        // Ordering and search
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public ProductOrderOptions prodOrderOption { get; set; } = 0;

        // Pagination
        [BindProperty(SupportsGet = true)]
        public int CurrPage { get; set; } = 1;
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 8;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(PageCount, PageSize));

        // Model properties
        [TempData]
        public string Message { get; set; }
        public List<Products> Products { get; set; }

        public void OnGet()
        {
            PageCount = _service.GetProductsQ(Search).Count();
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);
        }

        public IActionResult OnGetCart(string name, int prodID)
        {
            PageCount = _service.GetProductsQ(Search).Count();
            Products = _service.GetProducts(CurrPage, PageSize, prodOrderOption, Search);
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
                    CartOrderItems newCartItem = new() { ProductID = Products.Find(p => p.ProductID == prodID).ProductID, Amount = 1 };
                    cartCookie.Add(newCartItem);
                }

                json = JsonConvert.SerializeObject(cartCookie);
            }
            else
            {
                List<CartOrderItems> cartCookie = new();
                CartOrderItems cartItem = new() { ProductID = Products.Find(p => p.ProductID == prodID).ProductID, Amount = 1 };
                cartCookie.Add(cartItem);

                json = JsonConvert.SerializeObject(cartCookie);

            }
            Response.Cookies.Append("cart", json, new CookieOptions() { IsEssential = true, HttpOnly = true }); // Secure = true for HTTPS


            #endregion
            return RedirectToPage("Products");
        }
    }
}