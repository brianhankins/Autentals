using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        List<Vehicles> vehicle = new List<Vehicles>()
        {
            new Vehicles { Make = "Ford", Model = "F150", Year = 2017 },
            new Vehicles { Make = "Ford", Model = "Focus", Year = 2016 }

        };
    }
}