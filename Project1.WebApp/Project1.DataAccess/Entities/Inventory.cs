﻿using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Stores Store { get; set; }
    }
}
