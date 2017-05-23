using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Autentals.Controllers
{
    public class CustomersController : Controller
    {
        private DbModel _context;

        public CustomersController()
        {
            _context = new DbModel();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Customers/AllCustomers")]
        public ActionResult AllCustomers()
        {
            var customerData = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new AppViewModel()
            {
                Customers = customerData
            };

            return View(viewModel);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var getCustomerById = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(getCustomerById);
        }
    }
}