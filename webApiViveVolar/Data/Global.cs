using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace webApiViveVolar.Data
{
    public class Global
    {
        private static readonly Global instance = new Global();
        public static string connectionString;
        static Global() { }
        private Global()
        {
            connectionString = ConfigurationManager.ConnectionStrings["viveVolarDB"].ConnectionString;
        }

        public static Global Instance
        {
            get { return instance; }
        }

    }
}