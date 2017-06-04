using Autentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Membership> MembershipInformation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string MembershipName { get; set; }

    }
}