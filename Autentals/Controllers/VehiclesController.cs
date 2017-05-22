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

        [Route("Vehicles/AllVehicles")]
        public ActionResult AllVehicles()
        {
            List<Vehicle> vehicleData = new List<Vehicle>()
            {
                new Vehicle { Make = "Ford", Model = "F150", Year = 2017, Color = "Red", Id =1 },
                new Vehicle { Make = "Ford", Model = "Focus", Year = 2016, Color = "Blue", Id = 2 }
            };

            var viewModel = new AppViewModel()
            {
                Vehicles = vehicleData
            };

            return View(viewModel);
        }

        [Route("Vehicles/GetVehicle/{id}")]
        public ActionResult GetVehicle(int id)
        {
            List<Vehicle> vehicleData = new List<Vehicle>()
            {
                new Vehicle { Make = "Ford", Model = "F150", Year = 2017, Color = "Red", Id =1 },
                new Vehicle { Make = "Ford", Model = "Focus", Year = 2016, Color = "Blue", Id = 2 }
            };

            var getVehicleById = vehicleData.Find(i => i.Id == id);

            return View(getVehicleById);
        }
    }
}