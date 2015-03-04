using System;

namespace IvanovWebsite.admin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Master.ValidateAdminRole();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Users";
        }
    }
}