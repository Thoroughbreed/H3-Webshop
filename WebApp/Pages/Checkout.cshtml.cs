using System.Collections.Generic;
using System.Linq;
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
        [BindProperty]
        public List<OrderItems> Cart { get; set; } = new();
        public List<CartOrderItems> cartCookie { get; set; }
        public List<Products> Products { get; set; } = new();
        public Orders Order { get; set; }
        [BindProperty]
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
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Page();
            }
            else
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
                Customer = _service.CustExist(Customer);
                if (Customer.CustomerID > 0)
                {
                    Order = _service.CheckoutCustomer(Customer, Cart);
                }
                else
                {
                    Order = _service.CheckoutNewCust(Customer, Cart);
                }
                Response.Cookies.Delete("cart");

                _service.Commit();
                return RedirectToPage("./Success", new { guid = Order.OrderGuid, cID = Customer.CustomerID });
            }
        }
    }
}
