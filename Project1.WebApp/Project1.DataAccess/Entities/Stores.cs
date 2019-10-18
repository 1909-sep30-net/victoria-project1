using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Stores
    {
        public Stores()
        {
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
