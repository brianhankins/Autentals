﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Autentals.Models;

namespace Autentals.Connection
{
    public class DbService
    {
        private string databaseBeingUsed = "AutentalsDb";

        static string ConnVal(string connection)
        {
            return ConfigurationManager.ConnectionStrings[connection].ConnectionString;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var allCustomers = new List<Customer>();

            using (var conn = new SqlConnection(ConnVal(databaseBeingUsed)))
            using (var cmd = new SqlCommand("SP_GetAllCustomers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var firstName = reader["FirstName"].ToString();
                    var lastName = reader["LastName"].ToString();
                    var dob = (int)reader["DateOfBirth"];
                    var isSub = (bool)reader["IsSubscribed"];
                    var signUpFee = (int)reader["SignUpFee"];
                    var duration = (int)reader["DurationInMonths"];
                    var discount = (int)reader["Discount"];
                    var membershipName = reader["MembershipName"].ToString();

                    var membershipInfo = new MembershipType(signUpFee, duration, discount, membershipName);
                    var customer = new Customer(id, firstName, lastName, dob, isSub, membershipInfo);

                    allCustomers.Add(customer);
     
                }
                conn.Close();
            }
            return allCustomers;
            
        }




    }
}