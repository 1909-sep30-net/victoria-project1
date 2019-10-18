using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class Product
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Products must have a name", nameof(value));

                name = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Products must have a price", nameof(value));

                price = value;
            }
        }

        private int productId;

        public int ProductId
        {
            get => productId;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Products must have an ID", nameof(value));

                productId = value;
            }
        }



        public Product()
        { }
        public Product(string name, decimal price, int productId)
        {
            Name = name;
            Price = price;
            ProductId = productId;

        }
    }
}
