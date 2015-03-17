using Core;
using System;
using System.Linq;
using Core.Utilities;

namespace IvanovWebsite.admin
{
    public partial class OfferPage : System.Web.UI.Page
    {
        public Offer Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            var OfferID = Request.QueryString["id"].ToInt();
            Item = OfferRepository.GetSingleOffer(OfferID);
            if (Item != null)
            {
                Master.PageTitle = Item.OfferType;
                ManagerPlaceHolder.Visible = !string.IsNullOrWhiteSpace(Item.Manager);
                NoManagerPlaceHolder.Visible = !ManagerPlaceHolder.Visible;
            }
            else
            {
                Item = new Offer();
                Response.Redirect("offers.aspx");
            }
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            var R = new OfferRepository();
            R.UpdateOfferManager(Request.QueryString["id"].ToInt(), Master.UserObject.ID);
            Response.Redirect(Request.Url.OriginalString);
        }
    }
}