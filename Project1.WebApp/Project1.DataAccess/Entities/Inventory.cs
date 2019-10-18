using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Stores = new HashSet<Stores>();
        }

        public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<Stores> Stores { get; set; }
    }
}
