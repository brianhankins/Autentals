using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountAmount { get; set; }
        public string MembershipName { get; set; }

        public MembershipType(int signUpFee, int duration, int discount, string membershipName)
        {
            signUpFee = SignUpFee;
            duration = DurationInMonths;
            discount = DiscountAmount;
            membershipName = MembershipName;
        }
    }
}