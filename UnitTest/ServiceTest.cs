using System;
using Xunit;
using DataLayer;
using DataLayer.Models;
using ServiceLayer;
using System.Linq;

namespace UnitTest
{
    public class ServiceTest
    {
        [Fact]
        public void Test_Adding_New_User_To_DB()
        {
            using (var ct = new CoreContext())
            {
                var service = new ShopService(ct);
                service.AddUser("Unit", "Tester", "RoadRoad", 123, 2400, "1-800-Snow", null);
            }

            // ASSERT
            using (var ct = new CoreContext())
            {
                Assert.Equal("Tester", ct.Customers.OrderByDescending(c => c.CustomerID).First().LName);
                Assert.Null(ct.Customers.OrderByDescending(c => c.CustomerID).First().PhoneMobile);
                Assert.NotNull(ct.Customers.OrderByDescending(c => c.CustomerID).First().PhoneMain);
                Assert.Equal(4, ct.Customers.Count());
            }
        }

        [Fact]
        public void Test_Deleting_User_In_DB()
        {
            using (var ct = new CoreContext())
            {
                var service = new ShopService(ct);
                var user = ct.Customers.OrderBy(c => c.CustomerID).LastOrDefault();
                service.DeleteUser(user);
            }

            // ASSERT
            using (var ct = new CoreContext())
            {
                Assert.Equal(3, ct.Customers.Count());
            }
        }

        [Fact]
        public void Test_Editing_Existing_User_In_DB()
        {
            using (var ct = new CoreContext())
            {
                var service = new ShopService(ct);
                var uid = ct.Customers.Single(c => c.CustomerID == 3);
                service.EditUser(uid.CustomerID, "UnitX", "Tester", "Road Road", 132, 2400, "1-800-Snow", "1-555-Sun");
            }

            // ASSERT
            using (var ct = new CoreContext())
            {
                Assert.Equal("UnitX", ct.Customers.Single(c => c.CustomerID == 2).FName);
                Assert.NotNull(ct.Customers.Single(c => c.CustomerID == 2).PhoneMobile);
            }
        }

        [Fact]
        public void Test_Adding_Order()
        {
            using (var ct = new CoreContext())
            {
                var sevice = new ShopService(ct);
                var customer = ct.Customers.FirstOrDefault();

                sevice.AddOrder(customer);
            }

            // ASSERT
            using (var ct = new CoreContext())
            {
                Assert.NotNull(ct.Orders.First().OrderGuid);
                Assert.Equal(1, ct.Orders.First().OrderID);
            }
        }

    }
}
