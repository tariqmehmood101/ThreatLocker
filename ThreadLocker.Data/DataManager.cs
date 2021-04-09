using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ThreatLocker.Entities;

namespace ThreatLocker.Data
{
    public static class DataManager//: Connection
    {
        private static string Connectstring = "Data Source=.\\;Initial Catalog=ThreatLocker;Integrated Security=SSPI";
        private static SqlConnection con = new SqlConnection(Connectstring);
        private static SqlCommand Command;
        private static SqlDataReader SQLReader;
        
        public static IEnumerable<User> SearchUser(string SearchText)
        {
            IEnumerable<User> Users = new List<User>();
            Command = new System.Data.SqlClient.SqlCommand("usp_SearcAllUsers", con);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@SearhText", SearchText));

            try
            {
                con.Open();
                SQLReader = Command.ExecuteReader();
                Users =  MAPEntitites(SQLReader);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
           
            }
            return Users;
        }
        private static IEnumerable<User> MAPEntitites(SqlDataReader Reader)
        {
            List<User> Users = new List<User>();
            while (Reader.Read())
            {
                User SingleUser = new User();
                SingleUser.UserID =(int)(Reader["UserId"]);
                SingleUser.FirstName = Reader["FirstName"].ToString();
                SingleUser.LastName = Reader["LastName"].ToString();
                SingleUser.CustomerNumber = Reader["CustomerNumber"].ToString();
                SingleUser.PhoneNumber = Reader["PhoneNumber"].ToString();
                SingleUser.EmailAddress = Reader["EmailAddress"].ToString();
                Users.Add(SingleUser);
            }

            return Users;
        }
        public static void UpdateUserLogin()
        {
            
            Command = new System.Data.SqlClient.SqlCommand("usp_updateUserLastLogin", con);
            Command.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();             
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
                Command.Dispose();
            }
        }


    }
}
