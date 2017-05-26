﻿using Autentals.Connection;
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

        [Route("Customers/AllCustomers")]
        public ActionResult AllCustomers()
        {
            var customerVM = new AppViewModel()
            {
                Customers = new DbService().GetAllCustomers()
            };

            return View(customerVM);
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customerVM = new AppViewModel()
            {
                Customers = new DbService().GetSingleCustomer(id)
            };

            return View(customerVM);
        }
    }
}