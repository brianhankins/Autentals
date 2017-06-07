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
    [RoutePrefix("Customer")]
    public class CustomersController : Controller
    {

        [Route("AllCustomers")]
        public ActionResult AllCustomers()
        {
            var customerVM = new AppViewModel()
            {
                Customers = new CustomerRepository().GetAllCustomers()
            };

            return View(customerVM);
        }

        [Route("GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customerVM = new AppViewModel()
            {
                Customers = new CustomerRepository().GetSingleCustomer(id)
            };

            return View(customerVM);
        }

        [Route("NewCustomerForm")]
        public ActionResult NewCustomerForm()
        {
            var customerFormVM = new CustomerFormViewModel()
            {
                MembershipInformation = new MembershipRepository().GetMembershipInfo()
            };

            return View(customerFormVM);
        }

        [Route("EditCustomerForm/{id}")]
        public ActionResult EditCustomerForm(int id)
        {
            var customerFormVM = new AppViewModel()
            {
                MembershipInformation = new MembershipRepository().GetMembershipInfo(),
                Customers = new CustomerRepository().GetSingleCustomer(id).ToList()
            };

            return View(customerFormVM);
        }

        [HttpPost]
        public ActionResult SaveCustomer(CustomerFormViewModel model)
        {
            var validNewCustomer = ConverterService.CustomerFormConverter(model);

            CustomerRepository.AddNewCustomer(validNewCustomer);

            return RedirectToAction("AllCustomers", "Customers");
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerFormViewModel model)
        {
            var validCustomer = ConverterService.CustomerFormConverter(model);

            CustomerRepository.EditCustomer(validCustomer);

            return RedirectToAction("AllCustomers", "Customers");
        }

    }
}