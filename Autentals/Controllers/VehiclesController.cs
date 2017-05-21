using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autentals.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Random()
        {
            var vehicle = new Vehicles() { Name = "Ford" };
            var customers = new List<Customer>()
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomVehicleViewModel()
            {
                Vehicle = vehicle,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("vehicles/byYear/{year:regex(\\d{4})}")]
        public ActionResult ByYear(int year)
        {
            return Content(year.ToString());
        }
    }
}