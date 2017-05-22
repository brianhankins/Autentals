using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autentals.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        [Route("Customers/AllCustomers")]
        public ActionResult AllCustomers()
        {
            var customerData = CustomerData();

            var viewModel = new AppViewModel()
            {
                Customers = customerData
            };

            return View(viewModel);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var getCustomerById = CustomerData().FirstOrDefault(c => c.Id == id);

            return View(getCustomerById);
        }
        
        private IEnumerable<Customer> CustomerData()
        {
            List<Customer> customerData = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            return customerData;
        }

    }
}