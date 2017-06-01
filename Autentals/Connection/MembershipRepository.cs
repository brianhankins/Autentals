using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Autentals.Models;

namespace Autentals.Connection
{
    public class MembershipRepository : DbService
    {
        public IEnumerable<Membership> GetMembershipInfo()
        {
            var membershipInfo = new List<Membership>();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("msp_GetMembershipInfo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var membershipId = (int)reader["MembershipId"];
                    var signUpFee = (int)reader["SignUpFee"];
                    var duration = (int)reader["DurationInMonths"];
                    var discount = (int)reader["DiscountAmount"];
                    var membershipName = reader["MembershipName"].ToString();

                    var membership = new Membership(membershipId, signUpFee, duration, discount, membershipName);


                    membershipInfo.Add(membership);
                }
            }
            return membershipInfo;
        }

        public Membership GetSingleMembership(string membership_Name)
        {
            var singleMembershipInfo = new Membership();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("msp_GetSingleMembership", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@membershipName", membership_Name);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    singleMembershipInfo.MembershipId = (int)reader["MembershipId"];
                    singleMembershipInfo.SignUpFee = (int)reader["SignUpFee"];
                    singleMembershipInfo.DurationInMonths = (int)reader["DurationInMonths"];
                    singleMembershipInfo.DiscountAmount = (int)reader["DiscountAmount"];
                    singleMembershipInfo.MembershipName = reader["MembershipName"].ToString();
                }
            }
            return singleMembershipInfo;
        }

    }
}