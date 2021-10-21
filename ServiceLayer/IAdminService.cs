using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public interface IAdminService
    {
        public IQueryable<Customers> GetCustomersQ(string? searchTerm);
        public IQueryable<Vendors> GetVendorsQ();
        public IQueryable<Categories> GetCategoriesQ();
        public IQueryable<PriceDiscounts> GetPriceDiscountsQ();
        public List<Customers> GetCustomers(int currPage, int pageSize, CustomerOrderOptions options, string search = null);
        public void Update(object item);
        public void AddNew(object item);
        public void Delete(object item);
        public void Commit();
        public Products GetProductByID(int id);
        public IQueryable<Orders> GetOrdersQ();
        public Orders GetOrdersByGUID(string guid);
    }
}