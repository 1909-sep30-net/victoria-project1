using Microsoft.EntityFrameworkCore;
using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using Project1.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess.Repos
{
    public class StoreRepo : IStoreRepo
    {
        private ClothesEncountersContext context;

        public static ClothesEncountersContext GetContext()
        {
            string connectionString = SecretConfiguration.ConnectionString;

            DbContextOptions<ClothesEncountersContext> options = new DbContextOptionsBuilder<ClothesEncountersContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new ClothesEncountersContext(options);
        }
        public StoreRepo(ClothesEncountersContext context)
        {
            //context = new ClothesEncountersContext();
            this.context = context;

        }
        public Project1.BusinessLogic.Store GetStoreById(int id) => Mapper.MapStore(context.Stores.Find(id));

        public List<BusinessLogic.Store> GetAllStores()
        {
            IQueryable<Project1.DataAccess.Entities.Stores> stores = context.Stores
                .AsNoTracking();

            return stores.Select(Mapper.MapStore).ToList();


        }

        public Dictionary<Product, int> GetInventoryByStoreId(int storeId)
        {
            using var context = GetContext();
            List<Entities.Inventory> getInvent = context.Inventory.Where(i => i.StoreId == storeId).ToList();
            Dictionary<Product, int> burrito = new Dictionary<Product, int>();
            foreach (Entities.Inventory item in getInvent)
            {
                burrito.Add(new Product() { Name = context.Products.Single(p => p.ProductId == item.ProductId).Name, Price = context.Products.Single(p => p.ProductId == item.ProductId).Price, ProductId = item.ProductId }, (int)item.Quantity);
            }
            return burrito;

        }

        public Store GetStoreById()
        {
            throw new NotImplementedException();
        }
    }
}
