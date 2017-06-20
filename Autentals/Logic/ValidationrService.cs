using Autentals.Connection;
using Autentals.Models;
using Autentals.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autentals.Logic
{
    public class ValidationService : ValidationAttribute
    {
        public static Customer CustomerFormConverter(CustomerFormViewModel model)
        {
            if (model.BirthDate <= DateTime.Now.AddYears(-16))
            {
                return BuildValidCustomer(model);
            }

            Customer invalidCustomer = new Customer();
            
            return invalidCustomer;
        }

        private static Customer BuildValidCustomer(CustomerFormViewModel model)
        {
            Membership getMembershipInfo = new MembershipRepository().GetSingleMembership(model.MembershipName);

            Customer customer = new Customer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                BirthDate = model.BirthDate,
                MembershipTypeId = getMembershipInfo.MembershipId,
                IsValid = true
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