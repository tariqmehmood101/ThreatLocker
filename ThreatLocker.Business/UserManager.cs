using System;
using System.Collections.Generic;
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
            DataManager.UpdateUserLogin();
        }
    }
}
