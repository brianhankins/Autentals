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
    public class VehiclesController : Controller
    {
        // GET: Vehicles

        [Route("Vehicles/AllVehicles")]
        public ActionResult AllVehicles()
        {
            var vehicleVM = new AppViewModel()
            {
                Vehicles = new VehicleRepository().GetAllVehicles()
            };

            return View(vehicleVM);
        }

        [Route("Vehicles/GetVehicle/{id}")]
        public ActionResult GetVehicle(int id)
        {
            var vehicleVM = new AppViewModel()
            {
                Vehicles = new VehicleRepository().GetSingleVehicle(id)
            };

            return View(vehicleVM);
        }

        [Route("Vehicle/NewVehicleForm")]
        public ActionResult NewVehicleForm()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewVehicle(NewVehicleFormViewModel model)
        {
            var validNewVehicle = FormValidation.VehicleFormValidator(model);

            Vehicle vehicle = new VehicleRepository().AddNewVehicle(validNewVehicle);

            return RedirectToAction("AllVehicles", "Vehicles");
        }
    }
}