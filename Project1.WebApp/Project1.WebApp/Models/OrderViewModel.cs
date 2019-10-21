using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class OrderViewModel
    {
        [DisplayName("Customer ID")]
        [Required]
        public int CustomerId { get; set; }

        [DisplayName("Order ID")]
        [Required]
        public int OrderId { get; set; }

        [DisplayName("Order Date")]
        [Required]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Total")]
        [Required]
        public decimal Total { get; set; }

        [DisplayName("Store ID")]
        [Required]
        public int StoreId { get; set; }

        public List<StoreViewModel> AllStores;

        public List<ProductViewModel> Inventory;
            
    }
}
