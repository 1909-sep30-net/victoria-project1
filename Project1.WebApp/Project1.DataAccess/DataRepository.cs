using Microsoft.EntityFrameworkCore;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project1.BusinessLogic;

namespace Project1.DataAccess
{
    public class DataRepository
    {
        private ClothesEncountersContext context;

        public DataRepository(ClothesEncountersContext context)
        {
            //context = new ClothesEncountersContext();
            this.context = context;

        }

        public Project1.BusinessLogic.Store GetStoreById(int id) => Mapper.MapStore(context.Stores.Find(id));

        public void AddNewCustomer(Customer _cust)
        {
            Customers Cust = Mapper.MapDbCustomer(_cust);
            context.Add(Cust);
            context.SaveChanges();
        }

        public void AddNewOrder(Order _ord)
        {
            Orders Ord = Mapper.MapDbOrders(_ord);
            context.Add(Ord);
            context.SaveChanges();
        }



        public List<BusinessLogic.Customer> GetAllCustomers()
        {
            IQueryable<Project1.DataAccess.Entities.Customers> customers = context.Customers
                .AsNoTracking();

            return customers.Select(Mapper.MapCustomer).ToList();


        }

        public List<BusinessLogic.Store> GetAllStores()
        {
            IQueryable<Project1.DataAccess.Entities.Stores> stores = context.Stores
                .AsNoTracking();

            return stores.Select(Mapper.MapStore).ToList();


        }

        public Customer GetCustomerByFirstName(string firstName)

            => context.Customers.Select(Mapper.MapCustomer).Where(c => c.FirstName == firstName).FirstOrDefault();


        //public Dictionary<Product, int> GetInventoryByStoreId(int storeId)
        //{
        //    using var context = GetContext();
        //    List<Entities.Inventory> getInvent = context.Inventory.Where(i => i.StoreId == storeId).ToList();
        //    Dictionary<Product, int> burrito = new Dictionary<Product, int>();
        //    foreach (Entities.Inventory item in getInvent)
        //    {
        //        burrito.Add(new Product() { Name = context.Products.Single(p => p.ProductId == item.ProductId).Name, Price = context.Products.Single(p => p.ProductId == item.ProductId).Price, ProductId = item.ProductId }, (int)item.Quantity);
        //    }
        //    return burrito;

        //}

        public static ClothesEncountersContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<ClothesEncountersContext> options = new DbContextOptionsBuilder<ClothesEncountersContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new ClothesEncountersContext(options);
        }
    }
}
