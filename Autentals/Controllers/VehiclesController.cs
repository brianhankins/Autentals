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
        
        [Route("vehicles/allvehicles")]
        public ActionResult GetAllVehicles()
        {
            List<Vehicle> vehiclesVM = new List<Vehicle>()
            {
                new Vehicle { Make = "Ford", Model = "F150", Year = 2017 },
                new Vehicle { Make = "Ford", Model = "Focus", Year = 2016 }
            };

            return View("Vehicles", vehiclesVM);
        }

        //TODO: Probably dont need these below?
        [Route("vehicles/bymake/{make}")]
        public ActionResult ByMake(string make)
        {
            return View(make);
        }

        [Route("vehicles/bymodel/{model}")]
        public ActionResult ByModel(string model)
        {
            return View(model);
        }

        [Route("vehicles/byYear/{year:regex(\\d{4})}")]
        public ActionResult ByYear(int year)
        {
            return View(year);
        }
    }
}