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
            using (var cmd = new SqlCommand("SP_GetMembershipInfo", conn))
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
                conn.Close();
            }
            return membershipInfo;
        }
    }
}