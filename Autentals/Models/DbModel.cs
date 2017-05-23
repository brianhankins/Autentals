using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Autentals.Models
{
    public class DbModel : DbContext
    {
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
    }
}