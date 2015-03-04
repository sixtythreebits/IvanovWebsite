using System;

namespace IvanovWebsite.admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Administration";
        }
    }
}