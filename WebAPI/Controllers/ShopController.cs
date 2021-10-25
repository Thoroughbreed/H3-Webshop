using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.DTO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : Controller
    {
        private readonly IShopService _service;
        private readonly IAdminService _admin;
        public ShopController(IShopService service, IAdminService admin)
        {
            _service = service;
            _admin = admin;
        }
        // GET: /<controller>/

        [HttpGet]
        [Route("Products")]
        public IEnumerable<ProductDTO> GetProd(string? search)
        {
            var q = _service.GetProductsQ(search).ConvertToDTO();
            return q.ToArray();
        }

        [HttpGet]
        [Route("Customers")]
        public IEnumerable<CustomerDTO> GetCust(string? search)
        {
            var q = _admin.GetCustomersQ(search).ConvertToDTO();
            return q.ToArray();
        }

        [HttpGet]
        [Route("Orders")]
        public IEnumerable<OrderDTO> GetOrd()
        {
            var q = _admin.GetOrdersQ().ConvertToDTO();
            return q.ToArray();
        }
    }
}
