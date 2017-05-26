using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public int DateOfBirth { get; set; }
        public bool IsSubscribedNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

        public Customer(int id, string firstName, string lastName, int dob, bool isSubcribed, MembershipType membershipType)
        {
            id = Id;
            firstName = FirstName;
            lastName = LastName;
            dob = DateOfBirth;
            isSubcribed = IsSubscribedNewsletter;
            membershipType = MembershipType;
        }

    }
}