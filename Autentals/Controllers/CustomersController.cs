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
            List<Customer> customersData = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var viewModel = new AppViewModel()
            {
                Customers = customersData
            };

            return View(viewModel);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            List<Customer> customersData = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var getCustomer = customersData.Find(c => c.Id == id);

            return View(getCustomer);
        }
        
    }
}