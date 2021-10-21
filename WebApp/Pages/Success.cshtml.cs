using System;
using System.Web.Helpers;
using System.Web;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;

namespace WebApp.Pages
{
    public class SuccessModel : PageModel
    {
        private readonly IShopService _service;
        public SuccessModel(IShopService shopService)
        {
            _service = shopService;
        }

        public Customers Customer { get; set; }
        public string GUID { get; set; }
        public void OnGet(string guid, int cID)
        {
            Customer =_service.GetCustByID(cID);
            GUID = guid.Substring(0, 8);
            try
            {
                WebMail.SmtpServer = "send.one.com";
                //WebMail.SmtpPort = 465;
                WebMail.SmtpPort = 2525;
                WebMail.UserName = "debug@tved.it";
                WebMail.Password = "debugpassword";
                WebMail.From = "debug@tved.it";

                WebMail.Send(
                    Customer.EMail,
                    "Din ordre gik igennem!",
                    $"Fedt mand! Ordren gik igennem og den fik ordre nummer {GUID} - vi håber virkeligt at se dig igen en anden gang :)\n\nDe største hilsener\nTeamet bag Vegan Living"
                    );
                }
            catch (Exception ex)
            {  }
        }
    }
}
