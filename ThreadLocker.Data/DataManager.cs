using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ThreatLocker.Entities;

namespace ThreatLocker.Data
{
    public static class DataManager
    {
        private static string Connectstring = "Data Source=.\\;Initial Catalog=ThreatLocker;Integrated Security=SSPI";
        private static string ConnectstringHistory = "Data Source=.\\;Initial Catalog=ThreatLockerHistory;Integrated Security=SSPI";
        private static SqlConnection con;
        private static SqlCommand Command;
        private static SqlDataReader SQLReader;
        
        public static IEnumerable<User> SearchUser(string SearchText)
        {
            IEnumerable<User> Users = new List<User>();
            Command = new System.Data.SqlClient.SqlCommand("usp_SearcAllUsers", con = new SqlConnection(Connectstring));
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
        private static IEnumerable<UserLoginHistory> MAPHistoryEntitites(SqlDataReader Reader)
        {
            List<UserLoginHistory> UsersHistory = new List<UserLoginHistory>();
            while (Reader.Read())
            {
                UserLoginHistory SingleRecord = new UserLoginHistory();
                SingleRecord.UserID = (int)(Reader["UserId"]);
                SingleRecord.DateTime = (DateTime) (Reader["LoginTime"]);
                UsersHistory.Add(SingleRecord);
            }

            return UsersHistory;
        }
        public static IEnumerable<UserLoginHistory> GetUserLoginHistory()
        {
            IEnumerable<UserLoginHistory> LoginHistory = new List<UserLoginHistory>();
            Command = new System.Data.SqlClient.SqlCommand("usp_getUsersLastLogin", con = new SqlConnection(ConnectstringHistory));
            Command.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                SQLReader = Command.ExecuteReader();
                LoginHistory = MAPHistoryEntitites(SQLReader);
            }
            catch (Exception ex)
            {
                // We can log any exceptions
            }
            finally
            {
                con.Close();
                Command.Dispose();

            }
            return LoginHistory;

        }
        public static void UpdateUserLogin(int UserID,DateTime LogTime)
        {
            
            Command = new System.Data.SqlClient.SqlCommand("usp_updateUserLastLogin", con = new SqlConnection(Connectstring));
            Command.Parameters.Add(new SqlParameter("@UserID", UserID));
            Command.Parameters.Add(new SqlParameter("@LogTime", LogTime));
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
