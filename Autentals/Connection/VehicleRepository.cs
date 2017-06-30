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
    public class VehicleRepository : DbService
    {
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var allVehicles = new List<Vehicle>();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("vsp_GetAllVehicles", conn))
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
            }
            return allVehicles;
        }

        public IEnumerable<Vehicle> GetSingleVehicle(int id)
        {
            var singleVehicles = new List<Vehicle>();

            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("vsp_GetVehicle", conn))
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
            }
            return singleVehicles;
        }

        public static void AddNewVehicle(Vehicle vehicle)
        {
            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("vsp_AddVehicle", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@make", vehicle.Make);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@convertable", vehicle.IsConvertable);
                cmd.Parameters.AddWithValue("@seats", vehicle.Seats);
                cmd.Parameters.AddWithValue("@transmission", vehicle.TransmissionType);

                cmd.ExecuteNonQuery();

            }
        }

        public static void UpdateVehicle(Vehicle vehicle)
        {
            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("vsp_EditVehicle", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@id", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@make", vehicle.Make);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@convertable", vehicle.IsConvertable);
                cmd.Parameters.AddWithValue("@seats", vehicle.Seats);
                cmd.Parameters.AddWithValue("@transmission", vehicle.TransmissionType);

                cmd.ExecuteNonQuery();

            }
        }

        public static void DeleteVehicle(int id)
        {
            using (var conn = new SqlConnection(DbConnection()))
            using (var cmd = new SqlCommand("vsp_DeleteVehicle", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}