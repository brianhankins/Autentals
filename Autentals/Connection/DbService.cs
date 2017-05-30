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
        protected static string DbConnection()
        {
            string databaseBeingUsed = "AutentalsDb";

            return ConfigurationManager.ConnectionStrings[databaseBeingUsed].ConnectionString;
        }
    }
}