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
            List<Customer> customerData = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var viewModel = new AppViewModel()
            {
                Customers = customerData
            };

            return View(viewModel);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            List<Customer> customerData = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var getCustomerById = customerData.Find(c => c.Id == id);

            return View(getCustomerById);
        }
        
    }
}