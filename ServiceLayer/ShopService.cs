using System;
using DataLayer;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;

namespace ServiceLayer
{
    public class ShopService
    {
        private CoreContext _context;

        public ShopService(CoreContext ct)
        {
            _context = ct;
        }

        public void AddUser(string FName, string LName, string RoadName, int RoadNum, int PostNum, string? PhoneMain, string? PhoneCell)
        {
            Customers cust = new Customers
            {
                FName = FName,
                LName = LName,
                RoadName = RoadName,
                RoadNumber = RoadNum,
                PostNumber = PostNum,
                PhoneMain = PhoneMain,
                PhoneMobile = PhoneCell
            };
            _context.Customers.Add(cust);
            _context.SaveChanges();
        }

        public void DeleteUser(Customers customer)
        {
            var user = _context.Customers.Where(u => u == customer).FirstOrDefault();
            _context.Customers.Remove(user);
            _context.SaveChanges();
        }

        public void EditUser(int userID, string FName, string LName, string RoadName, int RoadNum, int PostNum, string? PhoneMain, string? PhoneCell)
        {
            Customers cust = _context.Customers.Where(u => u.CustomerID == userID).FirstOrDefault();
            cust.FName = FName;
            cust.LName = LName;
            cust.RoadName = RoadName;
            cust.RoadNumber = RoadNum;
            cust.PostNumber = PostNum;
            cust.PhoneMain = PhoneMain;
            cust.PhoneMobile = PhoneCell;

            _context.SaveChanges();
        }

        public void AddOrder(Customers customer)
        {
            Orders order = new Orders
            {
                CustomerID = customer.CustomerID
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
