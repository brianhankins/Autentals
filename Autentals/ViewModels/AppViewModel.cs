using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class AppViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Membership> MembershipInformation { get; set; }

    }
}