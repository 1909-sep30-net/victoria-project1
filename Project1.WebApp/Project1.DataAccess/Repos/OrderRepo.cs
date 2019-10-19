using Microsoft.EntityFrameworkCore;
using Project1.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.DataAccess.Repos
{
    public class OrderRepo
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
        public OrderRepo(ClothesEncountersContext context)
        {
            //context = new ClothesEncountersContext();
            this.context = context;

        }

        public void AddNewOrder(Order _ord)
        {
            Orders Ord = Mapper.MapDbOrders(_ord);
            context.Add(Ord);
            context.SaveChanges();
        }

    }
}
