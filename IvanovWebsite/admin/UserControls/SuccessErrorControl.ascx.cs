using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IvanovWebsite.admin.UserControls
{
    public partial class SuccessErrorControl : System.Web.UI.UserControl
    {
        public bool ShowSuccess
        {
            set { SuccessPlaceHolder.Visible = value; }            
        }

        public bool ShowError
        {
            set { SuccessPlaceHolder.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}