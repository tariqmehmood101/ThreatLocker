using System;
using System.Data.SqlClient;

namespace ThreatLocker.Data
{
    public class Connection
    {
        private string Connectstring = "Data Source=.\\;Initial Catalog=ThreadLocker;Integrated Security=SSPI";
        protected SqlConnection con;
        protected SqlCommand Command;
        protected SqlDataReader SQLReader;
        public Connection()
        {
            con = new SqlConnection(Connectstring);
            con.Open();
        }


    }
}
