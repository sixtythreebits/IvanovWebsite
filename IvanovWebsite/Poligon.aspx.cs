using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IvanovWebsite
{
    public partial class Poligon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}