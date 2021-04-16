using System;
using System.Collections.Generic;
using System.Linq;
using ThreatLocker.Data;
using ThreatLocker.Entities;

namespace ThreatLocker.Business
{
    public class UserManager
    {
        public IEnumerable<User> SearchUser(string SearchText)
        {
            
            return DataManager.SearchUser(SearchText);
        }
        public void UpdateUserLogin()
        {

            IEnumerable<UserLoginHistory> UsersHistory = DataManager.GetUserLoginHistory();
            
            foreach (var History in UsersHistory)
            {
                DataManager.UpdateUserLogin(History.UserID, History.DateTime);
            }
            
        }
    }
}
