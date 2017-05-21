using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class AllViewModels
    {
        public List<Vehicle> Vehicle { get; set; }
        public List<Customer> Customers { get; set; }

        //old view model taken from VehiclesController
        //var viewModel = new AllViewModels()
        //{
        //    Vehicle = vehicle,
        //    Customers = customers
        //};

        //    return View(viewModel);
    }

}