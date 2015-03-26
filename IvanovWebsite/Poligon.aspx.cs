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
            //var M = new Mail();
            //M.Send("mike@63bits.com", "test iframe", "<iframe width='650' height='3500' frameborder='0' src='http://ivanov.63bits.com/admin/OfferPage.aspx?id=13'></iframe>");
            Utility.ConvertPageFromUrlToPdf("http://ivanov.63bits.com/admin/OfferPage.aspx?id=13");
        }
    }
}