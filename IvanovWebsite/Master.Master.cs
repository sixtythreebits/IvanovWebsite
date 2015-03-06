using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IvanovWebsite
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            form1.Action = "/" + (Request.ApplicationPath.Length > 1 ? Request.RawUrl.Remove(0, 1) : Request.RawUrl.Remove(0, 1));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}