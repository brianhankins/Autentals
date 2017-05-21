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

        List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle { Make = "Ford", Model = "F150", Year = 2017 },
            new Vehicle { Make = "Ford", Model = "Focus", Year = 2016 }

        };
    }
}