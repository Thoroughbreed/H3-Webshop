using DataLayer;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using ServiceLayer.DTO;

namespace ServiceLayer
{
    public class ShopService : IShopService
    {
        private readonly CoreContext _context;

        public ShopService(CoreContext ct)
        { _context = ct; }
        public ShopService()
        { _context = new CoreContext(); }

        #region CLI METHODS - DEPRECATED
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
        #endregion
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void AddUser(Customers customer)
        {
            _context.Customers.Add(customer);
        }

        public void EditUser(Customers customer)
        {
            _context.Customers.Update(customer);
        }

        #region Queryables
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
        public IQueryable<Products> GetProductByCatQ(int catID)
        {
            return GetProductsQ("").Where(p => p.CategoryID == catID);
        }

        public IQueryable<Products> GetProductByIDQ(int prodID)
        {
            return GetProductsQ("").Where(p => p.ProductID == prodID);
        }

        public IQueryable<Categories> GetCategoryByIDQ(int catID)
        {
            return _context.Categories.Where(c => c.CategoryID == catID);
        }

        public IQueryable<OrderItems> GetOrderItemsQ()
        {
            return _context.OrderItems
                    .Include(o => o.ProductID)
                    .Include(o => o.OrderID)
                    .AsNoTracking();
        }
        #endregion

        public Products GetProduct(Products product)
        {
            return GetProductByIDQ(product.ProductID).FirstOrDefault();
        }

        public List<Products> GetProductsByCat(int currPage, int pageSize, int catID, ProductOrderOptions options, string search = null)
        {
            return GetProductsQ(search)
                .Where(p => p.CategoryID == catID)
                .OrderByOptions(options)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public List<Products> GetProducts(int currPage, int pageSize, ProductOrderOptions options, string search = null)
        {
            return GetProductsQ(search)
                .OrderByOptions(options)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Orders CheckoutCustomer(Customers customer, List<OrderItems> items)
        {
            customer.OrderAmount++;
            Orders o = new Orders() { CustomerID = customer.CustomerID };
            _context.Orders.Add(o);
            _context.SaveChanges();
            foreach (var item in items)
            {
                item.OrderID = o.OrderID;
                _context.OrderItems.Add(item);
            }
            _context.SaveChanges();
            return o;
        }

        public Orders CheckoutNewCust(Customers customer, List<OrderItems> items)
        {
            customer.OrderAmount = 1;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            Orders o = new Orders() { CustomerID = customer.CustomerID };
            _context.Orders.Add(o);
            _context.SaveChanges();
            foreach (var item in items)
            {
                item.OrderID = o.OrderID;
                _context.OrderItems.Add(item);
            }
            _context.SaveChanges();
            return o;
        }

        public Customers CustExist(Customers cust)
        {
            if (_context.Customers.Where(c => c.EMail == cust.EMail).Count() > 0)
            {
                return _context.Customers.Where(c => c.EMail == cust.EMail).FirstOrDefault();
            }
            return cust;
        }

        public Customers GetCustByID(int id)
        {
            return _context.Customers.Where(c => c.CustomerID == id).FirstOrDefault();
        }


    }

    public class DTOService : IDTOService
    {
        private readonly CoreContext _context = new CoreContext();

        public void UpdateFromDTO(ProductDTO product)
        {
            var p = _context.Products.Where(p => p.ProductID == product.ID).FirstOrDefault();
            p.Name = product.Name;
            p.Price = product.Price;
            p.CategoryID = _context.Categories.Where(c => c.Category == product.Category).FirstOrDefault().CategoryID;
            p.VendorID = _context.Vendors.Where(v => v.Name == product.Vendor).FirstOrDefault().VendorID;

            _context.Update(p);
            _context.SaveChanges();
        }

        public void AddFromDTO(Object o)
        {
            object item = null;
            if (o.GetType() == typeof(ProductDTO))
            {
                ProductDTO product = (ProductDTO)o;
                int? vndr = null;
                if (!string.IsNullOrWhiteSpace(product.Vendor))
                {
                    Vendors vend = _context.Vendors.Where(v => v.Name == product.Vendor).FirstOrDefault();
                    if (vend == null)
                    {
                        vend = new Vendors { Name = product.Vendor };
                        _context.Add(vend);
                    }
                    vndr = vend.VendorID;
                }

                Categories cat = _context.Categories.Where(c => c.Category == product.Category).FirstOrDefault();
                if (cat == null)
                {
                    cat = new Categories { Category = product.Category };
                    _context.Add(cat);
                }
                _context.SaveChanges();

                item = new Products
                {
                    Name = product.Name,
                    Price = product.Price,
                    CategoryID = cat.CategoryID,
                    SKU = new Guid().ToString().Substring(0, 8)
                };

                if (vndr != null)
                {
                    ((Products)item).VendorID = vndr.Value;
                }
            }

            if (o.GetType() == typeof(CustomerDTO))
            {
                CustomerDTO customer = (CustomerDTO)o;
                string[] name = customer.Name.Split(' ');
                string[] adr = customer.Address.Split(' ');
                string RoadName = adr[0];
                for (int i = 1; i < adr.Length - 1; i++)
                {
                    RoadName += ' ' + adr[i];
                }

                item = new Customers
                {
                    FName = name[0],
                    LName = name[1],
                    RoadName = RoadName,
                    RoadNumber = adr[adr.Length - 1],
                    PostNumber = Convert.ToInt16(customer.City.Split(' ')[0]),
                    EMail = customer.EMail
                };
            }

            if (item != null)
            {
                _context.Add(item);
                _context.SaveChanges();
            }
        }

        public void UpdateFromDTO(CustomerDTO customer)
        {
            var c = _context.Customers.Where(c => c.CustomerID == customer.id).FirstOrDefault();

            string[] name = customer.Name.Split(' ');
            c.FName = name[0];
            c.LName = name[1];

            string[] adr = customer.Address.Split(' ');
            c.RoadName = adr[0];
            for (int i = 1; i < adr.Length-1; i++)
            {
                c.RoadName += ' ' + adr[i];
            }
            c.RoadNumber = adr[adr.Length-1];

            c.PostNumber = Convert.ToInt16(customer.City.Split(' ')[0]);
            c.EMail = customer.EMail;

            _context.Update(c);
            _context.SaveChanges();
        }

        
    }

    public class AdminService : IAdminService
    {
        private readonly CoreContext _context = new CoreContext();

        #region Queryables (admin)
        public IQueryable<Customers> GetCustomersQ(string? searchTerm)
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

        public IQueryable<Vendors> GetVendorsQ()
        {
            return _context.Vendors.Where(v => v.VendorID > 0);
        }

        public IQueryable<Categories> GetCategoriesQ()
        {
            return _context.Categories.Where(c => c.CategoryID > 0);
        }

        public IQueryable<PriceDiscounts> GetPriceDiscountsQ()
        {
            return _context.PriceDiscounts.Where(p => p.PriceDiscountID > 0);
        }

        public IQueryable<Orders> GetOrdersQ()
        {
            return _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.City)
                .AsNoTracking();
        }
        #endregion

        public List<Customers> GetCustomers(int currPage, int pageSize, CustomerOrderOptions options, string search = null)
        {
            return GetCustomersQ(search)
                .OrderByOptions(options)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Products GetProductByID(int id)
        {
            return _context.Products
                .Where(p => p.ProductID == id)
                .FirstOrDefault();
        }

        public Orders GetOrdersByGUID(string guid)
        {
            return _context.Orders
                .Where(o => o.OrderGuid.ToString().Substring(0,8) == guid)
                .Include(o => o.OrderItems)
                    .ThenInclude(o => o.Products)
                .Include(o => o.Customer)
                    .ThenInclude(c => c.City)
                .AsNoTracking()
                .FirstOrDefault();
        }

        #region CRUD (Admin)
        public void Update(object item)
        {
            _context.Update(item);
        }

        public void AddNew(object item)
        {
            _context.Add(item);
        }

        public void Delete(object item)
        {
            _context.Remove(item);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}