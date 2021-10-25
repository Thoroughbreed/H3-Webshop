using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceLayer;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string json = Request.Cookies["cart"];
            List<CartOrderItems> cartCookie = new List<CartOrderItems>();
            if (!string.IsNullOrEmpty(json))
            {
                cartCookie = JsonConvert.DeserializeObject<List<CartOrderItems>>(json);
                int counter = cartCookie.Sum(a => a.Amount);
                return View(counter);
            }
            else
            {
                return View(0);
            }
        }
    }
}
