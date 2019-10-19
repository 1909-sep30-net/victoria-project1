using System;
using System.Collections.Generic;

namespace Project1.DataAccess.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuant { get; set; }
        public int OrderId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
