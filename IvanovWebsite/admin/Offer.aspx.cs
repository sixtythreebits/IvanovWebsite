using Core;
using System;
using System.Linq;
using Core.Utilities;

namespace IvanovWebsite.admin
{
    public partial class OfferPage : System.Web.UI.Page
    {
        public Offer Item;
        public int CommentCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
            CheckSession();
        }

        void CheckSession()
        {
            if (Session["CommentsAdded"] != null)
            {
                Session.Remove("CommentsAdded");
                CommentsTabActivePlaceHolder.Visible = true;                
            }
        }

        void InitStartUp()
        {
            var OfferID = Request.QueryString["id"].ToInt();
            Item = OfferRepository.GetSingleOffer(OfferID);
            if (Item != null)
            {
                Master.PageTitle = Item.OfferType;
                ManagerPlaceHolder.Visible = !string.IsNullOrWhiteSpace(Item.ManagersString);
                NoManagerPlaceHolder.Visible = !ManagerPlaceHolder.Visible;
                ExpiredPlaceHolder.Visible = Item.ExpDate < DateTime.Now;

                ApplyButtonPlaceHolder.Visible = Item.OfferManagers == null || (Item.OfferManagers.Where(m => m.ID == Master.UserObject.ID).Count() == 0);
                RemoveButtonPlaceHolder.Visible = !ApplyButtonPlaceHolder.Visible;

                InitComments();
            }
            else
            {
                Item = new Offer();
                Response.Redirect("offers.aspx");
            }
        }

        void InitComments()
        {
            var list = OfferRepository.ListOfferComments(Item.ID);
            CommentsRepeater.DataSource = list;
            CommentsRepeater.DataBind();
            CommentCount = list.Count;
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            var R = new OfferRepository();
            R.TSP_OfferManagers(0, null, Request.QueryString["id"].ToInt(), Master.UserObject.ID);
            Response.Redirect(Request.Url.OriginalString);
        }

        protected void RemoveFromOfferButton_Click(object sender, EventArgs e)
        {
            var R = new OfferRepository();
            R.TSP_OfferManagers(2, null, Request.QueryString["id"].ToInt(), Master.UserObject.ID);
            Response.Redirect(Request.Url.OriginalString);
        }

        protected void AddCommentButton_Click(object sender, EventArgs e)
        {
            if (CommentsTextBox.Text.Length > 0)
            {
                var R = new OfferRepository();
                R.TSP_OfferComments(
                    iud: 0,
                    Comment: CommentsTextBox.Text,
                    UserID: Master.UserObject.ID,
                    OfferID: Item.ID
                );
                if (R.IsError)
                {
                    SuccessErrorControl.ShowError = true;
                }
                else
                {
                    Session["CommentsAdded"] = true;
                }
            }
            Response.Redirect(Request.Url.OriginalString);
        }       
    }
}