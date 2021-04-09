using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreatLocker.Business;
using ThreatLocker.Entities;

namespace ThreadLocker
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            UserManager manager = new UserManager();
            IEnumerable<User> Users = manager.SearchUser(txtSearch.Text);
            LoadGrid(Users);
        }

        private void LoadGrid(IEnumerable<User> Users)
        {
            gvUsers.DataSource = Users;
            gvUsers.DataBind();
        }
    }
}