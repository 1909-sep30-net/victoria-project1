using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class Order
    {
        private int orderId;
        public int OrderId
        {
            get => orderId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("All orders must have an ID", nameof(value));

                orderId = value;
            }
        }

        public int StoreId;

        public int CustomerId;

        public DateTime DateOfOrder = new DateTime();

        public Dictionary<Product, int> cart = new Dictionary<Product, int>();

        private decimal orderTotal;
        public decimal OrderTotal
        {
            get => orderTotal;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Order total cannot be negative", nameof(value));

                orderTotal = value;
            }
        }

        public int OrderDetailId;
    }
}
