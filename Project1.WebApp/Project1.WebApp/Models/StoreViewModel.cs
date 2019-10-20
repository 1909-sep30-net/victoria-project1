using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class StoreViewModel
    {
        [DisplayName("ID")]
        public int StoreId { get; set; }

        [Required]
        public string City { get; set; }
    }
}
