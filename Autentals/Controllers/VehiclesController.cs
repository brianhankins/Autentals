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
            var vehicle = new List<Vehicles>()
            {
                new Vehicles { Make = "Ford", Model = "F150", Year = 2017 },
                new Vehicles { Make = "Ford", Model = "Focus", Year = 2016 }

            };

            var customers = new List<Customer>()
            {
                new Customer { FirstName = "Albert", LastName = "Zeeke", Age = 35 },
                new Customer { FirstName = "Ben", LastName = "Yorks", Age = 18 },
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