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

        [Route("customers")]
        public ActionResult AllCustomers()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var customerViewModel = new AppViewModel()
            {
                Customers = customers
            };

            return View(customerViewModel);
        }

        [Route("customer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35, Id = 1 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18, Id = 2 },
            };

            var getCustomer = customers.Find(c => c.Id == id);

            return View(getCustomer);
        }
        
    }
}