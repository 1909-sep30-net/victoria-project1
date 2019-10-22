using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [DisplayName("Stock")]
        public int ProductQuant { get; set; }

        [DisplayName("Quantity")]
        public int MaxQuant { get; set; }

        [DisplayName("Inventory ID")]
        public int InventoryId { get; set; }

        


    }
}
