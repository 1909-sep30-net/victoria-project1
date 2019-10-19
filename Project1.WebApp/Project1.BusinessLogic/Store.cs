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

        private string city;

        public string City
        {
            get => city;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Store must have a city", nameof(value));

                city = value;
            }
        }
        
    }
}
