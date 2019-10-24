using Microsoft.EntityFrameworkCore;
using Project1.BusinessLogic;
using Project1.DataAccess.Entities;
using Project1.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.DataAccess.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private ClothesEncountersContext context;

        public static ClothesEncountersContext GetContext()
        {
          

            DbContextOptions<ClothesEncountersContext> options = new DbContextOptionsBuilder<ClothesEncountersContext>()
                .UseSqlServer("CeDb")
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

        public void AddNewOrder()
        {
            throw new NotImplementedException();
        }
    }
}
