using Autentals.Connection;
using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Logic
{
    public class FormValidation
    {
        public static Customer CustomerFormValidator(NewCustomerFormViewModel model)
        {
            Membership getMembershipInfo = new MembershipRepository().GetSingleMembership(model.MembershipName);

            Customer customer = new Customer()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                MembershipTypeId = getMembershipInfo.MembershipId
            };

            return customer;
        }

        public static Vehicle VehicleFormValidator(NewVehicleFormViewModel model)
        {
            Vehicle vehicle = new Vehicle()
            {
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