using System;
using IvanovWebsite.Models;

namespace IvanovWebsite.admin
{
    public partial class Admin : AdminMasterPageBase
    {
        public string PageTitle { set; get; }

        protected void Page_Init(object sender, EventArgs e)
        {
            CheckAuthentication();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = PageTitle;
            AdminItemsPlaceHolder.Visible = UserObject.RoleCode == 1;
        }
    }
}