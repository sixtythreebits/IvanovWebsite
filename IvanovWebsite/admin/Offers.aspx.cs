﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IvanovWebsite.admin
{
    public partial class Offers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Client Submited Offers";
        }
    }
}