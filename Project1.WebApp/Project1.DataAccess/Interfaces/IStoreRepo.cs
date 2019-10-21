using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Project1.DataAccess.Interfaces
{
    public interface IStoreRepo
    {
      
        public List<BusinessLogic.Store> GetAllStores();

        public Project1.BusinessLogic.Store GetStoreById();


        public List<BusinessLogic.Order> GetOrdersByStoreId(int StoreId);

        public Dictionary<Product, int> GetInventoryByStoreId(int storeId);








    }
}
