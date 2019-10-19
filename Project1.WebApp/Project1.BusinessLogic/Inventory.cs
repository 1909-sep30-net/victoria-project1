using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class Inventory
    {
        private int inventoryId;
        public int InventoryId
        {
            get => inventoryId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid Inventory ID", nameof(value));
                inventoryId = value;
            }
        }

        public int ProductId;

        public int StoreId;

        private int quantity;

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stock cannot be negative", nameof(value));
                quantity = value;
            }
        }


    }
}
