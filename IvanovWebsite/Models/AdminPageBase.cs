using Core;
using System;

namespace IvanovWebsite.Models
{
    public class AdminMasterPageBase : System.Web.UI.MasterPage
    {
        public User UserObject { set; get; }

        public void CheckAuthentication()
        {
            UserObject = UsersRepository.GetFromSession();
            if (UserObject == null || !UserObject.IsAuthenticated)
            {
                Response.Redirect("~/");
            }
        }

        public void ValidateAdminRole()
        {
            if (UserObject == null || UserObject.RoleCode != 1)
            {
                Response.Redirect("~/");
            }
        }
    }
}