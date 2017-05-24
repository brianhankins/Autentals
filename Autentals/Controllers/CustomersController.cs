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
            

            return View();
        }

        [Route("Customer/GetCustomer/{id}")]
        public ActionResult GetCustomer(int id)
        {
           

            return View(id);
        }
    }
}