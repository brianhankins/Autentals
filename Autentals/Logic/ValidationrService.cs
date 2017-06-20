using Autentals.Connection;
using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Logic
{
    public class ValidationService
    {
        public static Customer CustomerFormConverter(CustomerFormViewModel model)
        {
            if (model.BirthDate >= DateTime.Now.AddYears(-15))
            {
                
            }


            Membership getMembershipInfo = new MembershipRepository().GetSingleMembership(model.MembershipName);

            Customer customer = new Customer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                MembershipTypeId = getMembershipInfo.MembershipId
            };

            return customer;
        }

        public static Vehicle VehicleFormConverter(VehicleFormViewModel model)
        {
            Vehicle vehicle = new Vehicle()
            {
                Id = model.Id,
                Year = model.Year,
                Make = model.Make,
                Model = model.Model,
                Color = model.Color,
                IsConvertable = model.IsConvertable,
                Seats = model.Seats,
                TransmissionType = model.TransmissionType
            };

            return vehicle;
        }
    }
}