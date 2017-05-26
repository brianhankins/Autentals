﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class MembershipType
    {
        public int MembershipId { get; set; }
        public int SignUpFee { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountAmount { get; set; }
        public string MembershipName { get; set; }

        public MembershipType(int membershipId, int signUpFee, int duration, int discount, string membershipName)
        {
            MembershipId = membershipId;
            SignUpFee = signUpFee;
            DurationInMonths = duration;
            DiscountAmount = discount;
            MembershipName = membershipName;
        }
    }
}