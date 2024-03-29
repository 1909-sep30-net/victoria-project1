﻿using Project1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.DataAccess
{
    public interface ICustRepo
    {
        public void AddNewCustomer(Customer customer);

        public List<BusinessLogic.Customer> GetAllCustomers();

        public List<Customer> GetCustomerByFirstName(string customer);

        public List<Order> GetOrdersByCustId(int custId);

       // public Order PlaceOrder(int id);

        public List<BusinessLogic.Store> GetAllStores();

        public Dictionary<Product, int> GetInventoryByStoreId(int storeId);

        public void AddNewOrder(Order _ord);

        public void UpdateInventory(BusinessLogic.Inventory invent);

        public void UpdateOrderDetails(BusinessLogic.OrderDetails od);






    }
}
