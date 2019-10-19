using Project1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.DataAccess
{
    public interface ICustRepo
    {
        public void AddNewCustomer();

        public List<BusinessLogic.Customer> GetAllCustomers();

        public Customer GetCustomerByFirstName();







    }
}
