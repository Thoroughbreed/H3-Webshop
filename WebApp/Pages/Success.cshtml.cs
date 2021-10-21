using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Pages
{
    public class SuccessModel : PageModel
    {
        private readonly ShopService _service = new();

        public Customers Customer { get; set; }
        public string GUID { get; set; }
        public void OnGet(string guid, int cID)
        {
            Customer =_service.GetCustByID(cID);
            GUID = guid.Substring(0, 8);
        }
    }
}
