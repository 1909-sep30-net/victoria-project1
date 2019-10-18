using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class Orders
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public int StoreId { get; set; }
        public int OrderDetailId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Stores Store { get; set; }
    }
}
