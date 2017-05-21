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
        [Route("customers/firstname/{firstname}")]
        public ActionResult FirstName(string firstName)
        {
            return View(firstName);
        }

        [Route("customers/lastname/{lastname}")]
        public ActionResult LastName(string lastName)
        {
            return View(lastName);
        }

        [Route("customers/byage/{age}")]
        public ActionResult ByAge(int age)
        {
            return View(age);
        }

    }
}