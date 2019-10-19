using Microsoft.EntityFrameworkCore;
using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1.DataAccess.Repos
{
    public class CustRepo
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

        public Customer GetCustomerByFirstName(string firstName)

           => context.Customers.Select(Mapper.MapCustomer).Where(c => c.FirstName == firstName).FirstOrDefault();

        public List<BusinessLogic.Customer> GetAllCustomers()
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



    }
}
