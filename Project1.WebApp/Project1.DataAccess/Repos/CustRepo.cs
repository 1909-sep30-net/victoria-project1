﻿using Microsoft.EntityFrameworkCore;
using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess.Repos
{
    public class CustRepo : ICustRepo
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
        public CustRepo(ClothesEncountersContext context)
        {
            //context = new ClothesEncountersContext();
            this.context = context;

        }

        public List<Customer> GetCustomerByFirstName(string firstname)

           => context.Customers.Select(Mapper.MapCustomer).Where(c => c.FirstName == firstname).ToList();

        public List<Customer> GetAllCustomers()
        {
            IQueryable<Project1.DataAccess.Entities.Customers> customers = context.Customers
                .AsNoTracking();

            return customers.Select(Mapper.MapCustomer).ToList();
        }

        public void AddNewCustomer(Customer _cust)
        {
            Customers Cust = Mapper.MapDbCustomer(_cust);
            context.Add(Cust);
            context.SaveChanges();
        }

        public void AddNewCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByFirstName()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByCustId(int custId)
        { 
            List<Order> orders = context.Orders.Select(Mapper.MapOrder).Where(c => c.CustomerId == custId).ToList();
            return orders;
        }

        public List<BusinessLogic.Store> GetAllStores()
        {
            IQueryable<Project1.DataAccess.Entities.Stores> stores = context.Stores
                .AsNoTracking();

            return stores.Select(Mapper.MapStore).ToList();


        }


        //public Order PlaceOrder(int id)
        //{
        //    //Order order = context.Orders.Add().Where(c => c.CustomerId == id)

        //    //return
        //}
    }
}
