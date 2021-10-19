using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace WebApp.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ShopService _service;
        public ShoppingCartViewComponent(ShopService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            int counter = 3;
            return View(counter);
        }
    }
}
