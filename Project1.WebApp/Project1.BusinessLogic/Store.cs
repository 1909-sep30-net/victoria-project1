using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class Store
    {
        private int storeId;
        public int StoreId
        {
            get => storeId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid Store ID", nameof(value));
                storeId = value;
            }
        }


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
    }
}
