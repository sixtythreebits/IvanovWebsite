using System;

namespace IvanovWebsite
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "За нас";
        }
    }
}