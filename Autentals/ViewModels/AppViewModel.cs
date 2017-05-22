using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class AppViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<Customer> Customers { get; set; }

    }
}