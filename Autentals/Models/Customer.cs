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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        public Membership MembershipInfo { get; set; }

        public int MembershipTypeId { get; set; }



        ///<summary>Used for posting data to database</summary>
        public Customer() { }

        ///<summary>Customer basic( incl. BirthDate) information</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
        }

        ///<summary>All customer details including membership info</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob, Membership membershipInfo)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
            MembershipInfo = membershipInfo;
        }

    }
}