using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autentals.ViewModels
{
    public class VehicleFormViewModel
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public bool IsConvertable { get; set; }
        public int Seats { get; set; }
        public string TransmissionType { get; set; }
    }
}