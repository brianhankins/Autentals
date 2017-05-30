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
                    var membershipId = (int)reader["MembershipId"];
                    var signUpFee = (int)reader["SignUpFee"];
                    var duration = (int)reader["DurationInMonths"];
                    var discount = (int)reader["DiscountAmount"];
                    var membershipName = reader["MembershipName"].ToString();

                    var membershipInfo = new Membership(membershipId, signUpFee, duration, discount, membershipName);
                    var customer = new Customer(id, firstName, lastName, membershipInfo);

                    allCustomers.Add(customer);

                }
                conn.Close();
            }
            return allCustomers;
        }

        public IEnumerable<Customer> GetSingleCustomer(int id)
        {
            var singleCustomers = new List<Customer>();

            using (var conn = new SqlConnection(ConnVal(databaseBeingUsed)))
            using (var cmd = new SqlCommand("SP_GetCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var firstName = reader["FirstName"].ToString();
                    var lastName = reader["LastName"].ToString();

                    var dob = new DateTime();
                    if (!Convert.IsDBNull(reader["BirthDate"]))
                    {
                        dob = (DateTime)reader["BirthDate"];
                    }

                    var membershipId = (int)reader["MembershipId"];
                    var signUpFee = (int)reader["SignUpFee"];
                    var duration = (int)reader["DurationInMonths"];
                    var discount = (int)reader["DiscountAmount"];
                    var membershipName = reader["MembershipName"].ToString();

                    var membershipInfo = new Membership(membershipId, signUpFee, duration, discount, membershipName);
                    var singleCustomer = new Customer(id, firstName, lastName, dob, membershipInfo);

                    singleCustomers.Add(singleCustomer);
                }

                conn.Close();
            }
            return singleCustomers;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var allVehicles = new List<Vehicle>();

            using (var conn = new SqlConnection(ConnVal(databaseBeingUsed)))
            using (var cmd = new SqlCommand("SP_GetAllVehicles", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var year = (int)reader["Year"];
                    var make = reader["Make"].ToString();
                    var model = reader["Model"].ToString();

                    var vehicle = new Vehicle(id, year, make, model);

                    allVehicles.Add(vehicle);

                }
                conn.Close();
            }
            return allVehicles;
        }

        public IEnumerable<Vehicle> GetSingleVehicle(int id)
        {
            var singleVehicles = new List<Vehicle>();

            using (var conn = new SqlConnection(ConnVal(databaseBeingUsed)))
            using (var cmd = new SqlCommand("SP_GetVehicle", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var year = (int)reader["Year"];
                    var make = reader["Make"].ToString();
                    var model = reader["Model"].ToString();
                    var color = reader["Color"].ToString();
                    var isConvertable = (bool)reader["IsConvertable"];
                    var seats = (int)reader["Seats"];
                    var transType = reader["TransmissionType"].ToString();

                    var singleVehicle = new Vehicle(id, year, make, model, color, isConvertable, seats, transType);

                    singleVehicles.Add(singleVehicle);
                }

                conn.Close();
            }
            return singleVehicles;
        }

        public IEnumerable<Membership> GetMembershipInfo()
        {
            var membershipInfo = new List<Membership>();

            using (var conn = new SqlConnection(ConnVal(databaseBeingUsed)))
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