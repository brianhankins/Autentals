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
            var vehicleFormVM = new VehicleFormViewModel();
            
            return View(vehicleFormVM);
        }


        [Route("Vehicles/EditVehicleForm/{id}")]
        public ActionResult EditVehicleForm(int id)
        {
            var vehicleVM = new AppViewModel()
            {
                Vehicles = new VehicleRepository().GetSingleVehicle(id).ToList()
            };

            return View(vehicleVM);
        }


        [HttpPost]
        public ActionResult SaveVehicle(VehicleFormViewModel vehicleVM)
        {
            var validNewVehicle = ConverterService.VehicleFormConverter(vehicleVM);

            VehicleRepository.AddNewVehicle(validNewVehicle);

            return RedirectToAction("AllVehicles", "Vehicles");
        }


        [HttpPost]
        public ActionResult UpdateVehicle(VehicleFormViewModel viewModel)
        {
            
            var validVehicle = ConverterService.VehicleFormConverter(viewModel);

            VehicleRepository.UpdateVehicle(validVehicle);

            return RedirectToAction("AllVehicles", "Vehicles");
        }
    }
}