using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        List<Customer> customers = new List<Customer>()
        {
            new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35 },
            new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18 },
        };
    }
}