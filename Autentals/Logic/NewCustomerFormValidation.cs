using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Logic
{
    public class NewCustomerFormValidation
    {
        public static Customer FormValidator(NewCustomerFormViewModel model)
        {
            Customer customer = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate
            };

            var membershipName = model.MembershipName;

            return customer;
        }
    }
}