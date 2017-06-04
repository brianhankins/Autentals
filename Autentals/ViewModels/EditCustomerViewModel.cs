using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class EditCustomerViewModel
    {
        public IEnumerable<Membership> MembershipInformation { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
    }
}