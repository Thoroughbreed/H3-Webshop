using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public interface IShopService
    {
        public void Commit();
        public void AddUser(Customers customer);
        public void EditUser(Customers customer);
        public Products GetProduct(Products product);
        public List<Products> GetProductsByCat(int currPage, int pageSize, int catID, ProductOrderOptions options, string search = null);
        public List<Products> GetProducts(int currPage, int pageSize, ProductOrderOptions options, string search = null);
        public Orders CheckoutCustomer(Customers customer, List<OrderItems> items);
        public Orders CheckoutNewCust(Customers customer, List<OrderItems> items);
        public Customers CustExist(Customers cust);
        public Customers GetCustByID(int id);
        public IQueryable<Products> GetProductsQ(string? searchTerm);
        public IQueryable<OrderItems> GetOrderItemsQ();
        public IQueryable<Categories> GetCategoryByIDQ(int catID);
        public IQueryable<Products> GetProductByIDQ(int prodID);
        public IQueryable<Products> GetProductByCatQ(int catID);
    }
}