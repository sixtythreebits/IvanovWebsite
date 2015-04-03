using System;
using IvanovWebsite.Models;
using System.Drawing;

namespace IvanovWebsite.admin
{
    public partial class Offers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageTitle = "Client Submited Offers";
            OffersGrid.Columns["Email"].Visible = Master.UserObject.IsAdmin;
            OffersGrid.Columns[OffersGrid.Columns.Count - 2].Visible = Master.UserObject.IsAdmin;
        }

        protected void OffersGrid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "ExpDate" && e.CellValue as DateTime? < DateTime.Now)
            {
                e.Cell.BackColor = Color.Coral;
            }
        }
    }
}