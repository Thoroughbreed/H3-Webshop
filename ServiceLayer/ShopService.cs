using DataLayer;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class ShopService
    {
        private readonly CoreContext _context = new CoreContext();

        public ShopService(CoreContext ct)
        { }
        public ShopService()
        { }
        public void Commit()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// Adding a new user to context
        /// </summary>
        /// <param name="FName">First name</param>
        /// <param name="LName">Last name</param>
        /// <param name="RoadName">Road name</param>
        /// <param name="RoadNum">Road number</param>
        /// <param name="PostNum">Post number</param>
        /// <param name="PhoneMain">Phone number (main)</param>
        /// <param name="PhoneCell">Phone number (secondary)</param>
        public void AddUser(string FName, string LName, string RoadName, string RoadNum, int PostNum, string? PhoneMain, string? PhoneCell)
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
        }

        public void AddUser(Customers customer)
        {
            _context.Customers.Add(customer);
        }

        /// <summary>
        /// Deleting user from context
        /// </summary>
        /// <param name="customer">Customer object</param>
        public void DeleteUser(Customers customer)
        {
            var user = _context.Customers.Where(u => u == customer).FirstOrDefault();
            _context.Customers.Remove(user);
        }

        /// <summary>
        /// Editing already existing user
        /// </summary>
        /// <param name="userID">Customer ID</param>
        /// <param name="FName">First name</param>
        /// <param name="LName">Last name</param>
        /// <param name="RoadName">Road name</param>
        /// <param name="RoadNum">Road number</param>
        /// <param name="PostNum">Post number</param>
        /// <param name="PhoneMain">Phone number (main)</param>
        /// <param name="PhoneCell">Phone number (secondary)</param>
        public void EditUser(int userID, string FName, string LName, string RoadName, string RoadNum, int PostNum, string? PhoneMain, string? PhoneCell)
        {
            Customers cust = _context.Customers.Where(u => u.CustomerID == userID).FirstOrDefault();
            cust.FName = FName;
            cust.LName = LName;
            cust.RoadName = RoadName;
            cust.RoadNumber = RoadNum;
            cust.PostNumber = PostNum;
            cust.PhoneMain = PhoneMain;
            cust.PhoneMobile = PhoneCell;
        }

        public void EditUser(Customers customer)
        {
            _context.Customers.Add(customer);
        }

        /// <summary>
        /// Creating a new order connected to current user
        /// </summary>
        /// <param name="customer">Customer object</param>
        public void AddOrder(Customers customer)
        {
            Orders order = new Orders
            {
                CustomerID = customer.CustomerID
            };

            _context.Orders.Add(order);
        }

        public IQueryable<Products> GetProductsQ(string? searchTerm)
        {
            var q = _context.Products.Include(p => p.Category)
                .Include(p => p.PriceDiscount)
                .Include(p => p.Vendor)
                .AsNoTracking();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return q;
            }
            return q.Where(p => p.Name.Contains(searchTerm) ||
                                p.Category.Category.Contains(searchTerm) ||
                                p.Vendor.Name.Contains(searchTerm));
        }
        public List<Products> GetProducts(int currPage, int pageSize, ProductOrderOptions options, string search = null)
        {
            return GetProductsQ(search)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .OrderByOptions(options)
                .ToList();
        }
    }

    public class AdminService
    {
        private readonly CoreContext _context = new CoreContext();
        public IQueryable<Customers> GetCustomersQ(string ? searchTerm)
        {
            var q = _context.Customers
                .Include(c => c.City)
                .AsNoTracking(); ;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return q;
            }
            return q.Where(c => c.FName.Contains(searchTerm) ||
                                c.LName.Contains(searchTerm) ||
                                c.City.Name.Contains(searchTerm));
        }

        public List<Customers> GetCustomers(int currPage, int pageSize, CustomerOrderOptions options, string search = null)
        {
            return GetCustomersQ(search)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .OrderByOptions(options)
                .ToList();
        }
    }
}