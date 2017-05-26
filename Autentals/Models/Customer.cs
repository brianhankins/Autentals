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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsSubscribedNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }

        ///<summary>Customer basic details</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
        }

        ///<summary>All customer details including membership info</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob, bool isSubcribed, MembershipType membershipInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
            IsSubscribedNewsletter = isSubcribed;
            MembershipType = membershipInfo;
        }

    }
}