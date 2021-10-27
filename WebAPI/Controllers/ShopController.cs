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
        private readonly IDTOService _DTOService;

        public ShopController(IShopService service, IAdminService admin, IDTOService dto)
        {
            _service = service;
            _admin = admin;
            _DTOService = dto;
        }

        //Products
        [HttpGet]
        [Route("Products")]
        public IActionResult GetProd(string? search)
        {
            var q = _service.GetProductsQ(search).ConvertToDTO();
            if (q.Count() < 1)
            {
                return NoContent();
            }
            return Ok(q.ToArray());
        }

        [HttpPut]
        [Route("Products")]
        public IActionResult PutProd(ProductDTO product)
        {
            var p = _service.GetProductsQ(null).Where(p => p.ProductID == product.ID).ConvertToDTO().FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            try
            {
                _DTOService.UpdateFromDTO(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("Products")]
        public IActionResult PostProd(ProductDTO[] product)
        {
            try
            {
                _DTOService.AddFromDTO(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(product);
        }

        // Customers
        [HttpGet]
        [Route("Customers")]
        public IActionResult GetCust(string? search)
        {
            var q = _admin.GetCustomersQ(search).ConvertToDTO();
            if (q.Count() < 1)
            {
                return NoContent();
            }
            return Ok(q.ToArray());
        }

        [HttpPut]
        [Route("Customers")]
        public IActionResult PutCust(CustomerDTO customer)
        {
            var c = _service.GetCustByID(customer.id);
            if (c == null)
            {
                return NotFound();
            }
            try
            {
                _DTOService.UpdateFromDTO(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }

        [HttpPost]
        [Route("Customers")]
        public IActionResult PostCust(CustomerDTO[] customer)
        {
            try
            {
                _DTOService.AddFromDTO(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(customer);
        }

        // Orders
        [HttpGet]
        [Route("Orders")]
        public IActionResult GetOrd(string? guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
            {
                var q = _admin.GetOrdersQ().ConvertToDTO();
                if (q.Count() < 1)
                {
                    return NoContent();
                }
                return Ok(q.ToArray());
            }
            var o = _admin.GetOrdersByGUID(guid);
            if (o == null)
            {
                return NoContent();
            }
            return Ok(o.ToDto());
        }

        [HttpPost]
        [Route("Orders")]
        public IActionResult PostOrd(OrderItemDTO[] order)
        {
            Orders o;
            try
            {
                o = (Orders)_DTOService.AddFromDTO(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return StatusCode(201, o.OrderGuid.ToString().Substring(0,8));
        }
    }
}
