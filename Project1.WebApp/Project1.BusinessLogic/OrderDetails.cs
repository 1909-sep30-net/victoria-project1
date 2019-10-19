using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class OrderDetails
    {
        private int orderDetailId;
        public int OrderDetailId
        {
            get => orderDetailId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid Order Detail ID", nameof(value));
                orderDetailId = value;
            }
        }

        public int ProductId;

        public int OrderId;

        private int productQuant;
        public int OrderDeatailId;

        public int ProductQuant
        {
            get => productQuant;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stock cannot be negative", nameof(value));
                productQuant = value;
            }
        }
    }
}
