﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.Models
{
    public class CustomerViewModel
    {
        [DisplayName("ID")] 
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required] 
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required] 
        public string LastName { get; set; }












    }
}
