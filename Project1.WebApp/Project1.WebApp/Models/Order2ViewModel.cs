using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class Order2ViewModel
    {
        public List<ProductViewModel> Inventory { get; set; } = new List<ProductViewModel>();

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public int StoreId { get; set; }
    }
}
