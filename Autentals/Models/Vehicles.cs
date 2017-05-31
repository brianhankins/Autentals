using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsConvertable { get; set; }
        public int Seats { get; set; }
        public string TransmissionType { get; set; }

        ///<summary>Used for posting data to database</summary>
        public Vehicle() { }

        ///<summary>Vehicle basic details</summary>
        public Vehicle(int id, int year, string make, string model)
        {
            Id = id;
            Year = year;
            Make = make;
            Model = model;
        }

        public Vehicle(int id, int year, string make, string model, string color, bool convertable, int seats, string transType)
        {
            Id = id;
            Year = year;
            Make = make;
            Model = model;
            Color = color;
            IsConvertable = convertable;
            Seats = seats;
            TransmissionType = transType;
        }
    }
}