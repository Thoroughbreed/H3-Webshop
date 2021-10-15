using DataLayer;
using ServiceLayer;
using Microsoft.EntityFrameworkCore;
using System;

namespace Webshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<CoreContext>().UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = Webshop; Trusted_Connection = True;").Options;
            Console.WriteLine("Hello World!");
            using (var ct = new CoreContext())
            {
                var service = new ShopService(ct);
                service.AddUser("Test", "User", "TestRoad", "123", 6270, "42343424", null);
            }
        }
    }
}
