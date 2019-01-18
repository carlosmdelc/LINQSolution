using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQList
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Customer> stateQuery =
                from customer in fillCustomersList()
                where customer.lastName.Contains("ez")
                select customer;

            foreach (Customer c in stateQuery)
            {
                Console.WriteLine(c.lastName);
            }

            foreach (var customer in fillCustomersList())
            {
                Console.WriteLine(customer.firstName);
            }
            Console.ReadKey();
        }

        public static List<Customer> fillCustomersList()
        {
            var customers = new List<Customer>()
            {
                new Customer { firstName = "Carlos", lastName = "Martinez", stateOfResidence = "MX", moneySpent = 54.90, itemsPurchased = 540 },
                new Customer { firstName = "Gerardo", lastName = "Lopez", stateOfResidence = "CA", moneySpent = 854.90, itemsPurchased = 1548 },
                new Customer { firstName = "Monica", lastName = "Sanchez", stateOfResidence = "AU", moneySpent = 564.90, itemsPurchased = 8540 },
                new Customer { firstName = "Seth", lastName = "Rodriguez", stateOfResidence = "US", moneySpent = 754.90, itemsPurchased = 5460 },
                new Customer { firstName = "Claudia", lastName = "Shawn", stateOfResidence = "IT", moneySpent = 1254.90, itemsPurchased = 450 }
            };

            return customers;
        }
    }
}
