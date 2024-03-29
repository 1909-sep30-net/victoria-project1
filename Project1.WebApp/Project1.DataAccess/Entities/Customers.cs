﻿using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Name { get => FirstName + " " + LastName; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
