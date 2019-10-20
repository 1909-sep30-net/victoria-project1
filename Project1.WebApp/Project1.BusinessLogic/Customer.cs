using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.BusinessLogic
{
    public class Customer
    {
        private string firstName;
        public string FirstName
        {

            get => firstName;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Must have a first name", nameof(value));

                firstName = value;
            }


        }


        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException("Must have a last name", nameof(value));

                lastName = value;
            }

        }

        public string Name { get => FirstName + " " + LastName; }


        private int id;
        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid Customer ID", nameof(value));
                id = value;
            }
        }



        public Customer()
        { }
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
    }
}
