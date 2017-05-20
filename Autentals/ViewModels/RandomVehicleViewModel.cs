using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class RandomVehicleViewModel
    {
        public Vehicles Vehicle { get; set; }
        public List<Customer> Customers { get; set; }
    }
}