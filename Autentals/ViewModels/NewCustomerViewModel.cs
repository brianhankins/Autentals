using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<Membership> MembershipInformation { get; set; }
        public Customer Customer { get; set; }
    }
}