using Autentals.Connection;
using Autentals.Logic;
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

        [Route("Customer/NewCustomerForm")]
        public ActionResult NewCustomerForm()
        {
            var customerFormVM = new NewCustomerFormViewModel()
            {
                MembershipInformation = new MembershipRepository().GetMembershipInfo()
            };

            return View(customerFormVM);
        }

        [HttpPost]
        public ActionResult CreateNewCustomer(NewCustomerFormViewModel model)
        {
            var validNewCustomer = FormValidation.CustomerFormValidator(model);

            Customer customer = new CustomerRepository().AddNewCustomer(validNewCustomer);

            return RedirectToAction("AllCustomers", "Customers");
        }
    }
}