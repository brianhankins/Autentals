using Autentals.Connection;
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

        [Route("Customer/AllCustomers")]
        public ActionResult AllCustomers()
        {
            var customerVM = new AppViewModel()
            {
                Customers = new CustomerRepository().GetAllCustomers()
            };

            return View(customerVM);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customerVM = new AppViewModel()
            {
                Customers = new CustomerRepository().GetSingleCustomer(id)
            };

            return View(customerVM);
        }

        [Route("Customer/NewCustomer")]
        public ActionResult NewCustomerForm()
        {
            var newCustomerForm = new NewCustomerFormViewModel()
            {
                MembershipInformation = new MembershipRepository().GetMembershipInfo().ToList()
            };

            return View(newCustomerForm);
        }

        [HttpPost]
        public ActionResult AddNewCustomer(Customer customer)
        {
            //Need DBService method to add customer here
            //somthing.SaveChanges();


            return RedirectToAction("AllCustomers", "Customers");
        }
    }
}