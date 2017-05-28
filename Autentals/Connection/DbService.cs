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
                    var membershipName = reader["MembershipName"].ToString();

                    var membershipInfo = new Membership(membershipName);
                    var customer = new Customer(id, firstName, lastName, membershipInfo);

                    allCustomers.Add(customer);
     
                }
                conn.Close();
            }
            return allCustomers;
        }

        //TODO: Refactor. This needs to be changed to GetAllCustomers. 
        //Create new constructor for membership model (and rename MembershipType model to just Memberships)
        //Change name of SP_GetCustomer to SP_GetAllCustomers
        //Change Store Procedure to only get these 3 fields below for this view.
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
                    var membershipName = reader["MembershipName"].ToString();

                    var membershipInfo = new Membership(membershipName);
                    var singleCustomer = new Customer(id, firstName, lastName, membershipInfo);

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
    }
}