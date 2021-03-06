﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }

        public Membership MembershipInfo { get; set; }

        public bool IsValid { get; set; }

        ///<summary>Used for posting data to database</summary>
        public Customer() { }

        ///<summary>Customer basic( incl. BirthDate) information</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob)
        {
            CustomerId = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
        }

        ///<summary>All customer details including membership info</summary>
        public Customer(int id, string firstName, string lastName, DateTime dob, Membership membershipInfo)
        {
            CustomerId = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dob;
            MembershipInfo = membershipInfo;
        }

    }
}