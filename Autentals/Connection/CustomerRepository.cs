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
    public class CustomerRepository : DbService
    {
        public IEnumerable<Customer> GetAllCustomers()
        {
            var allCustomers = new List<Customer>();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("csp_GetAllCustomers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["Id"];
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
                    var customer = new Customer(id, firstName, lastName, dob, membershipInfo);

                    allCustomers.Add(customer);

                }
            }
            return allCustomers;
        }

        public IEnumerable<Customer> GetSingleCustomer(int id)
        {
            var singleCustomers = new List<Customer>();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("csp_GetCustomer", conn))
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
            }
            return singleCustomers;
        }

        public Customer AddNewCustomer(Customer customer)
        {
            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("csp_AddCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                //SP_AddCustomer is store proc for inserting into db. (required: firstName, lastName, dob, membershipId)
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                cmd.Parameters.AddWithValue("@dob", customer.BirthDate);
                cmd.Parameters.AddWithValue("@membershipId", customer.MembershipTypeId);

                cmd.ExecuteNonQuery();

            }
            return customer;
        }
    }
}