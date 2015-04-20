using Core;
using System;
using System.Linq;
using Core.Utilities;
using System.Threading.Tasks;

namespace IvanovWebsite
{
    public partial class OfferPage : System.Web.UI.Page
    {
        public Offer Item;
        public int? OfferID;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            OfferID = Request.QueryString["id"].ToInt();            
            Item = OfferRepository.GetSingleOffer(OfferID);
            if (Item != null)
            {
                Master.PageTitle = Item.OfferTypeCode == 1 ? "Нова оферта" : "Провери оферта";

                TransportPricePlaceHolder.Visible =
                RefererWebsitePlaceHolder.Visible = Item.OfferTypeCode == 2;

                FromLocationLiteral.Text = Item.LocationFrom;
                ToLocationLiteral.Text = Item.LocationTo;

                if (Item.StartDate.HasValue)
                {
                    HFDateFrom.Value = Item.StartDate.Value.ToString("MMM dd, yyyy");
                }

                if (Item.EndDate.HasValue)
                {
                    HFDateTo.Value = Item.EndDate.Value.ToString("MMM dd, yyyy");
                }

                IsOneWayRadio.Checked = Item.IsOneWay;
                IsTwoWayRadio.Checked = Item.IsTwoWay;
              

                switch (Item.TravelersCode)
                {
                    case 1: { AloneRadio.Checked = true; break; }
                    case 2: { CoupleRadio.Checked = true; break; }
                    case 3: { FamilyRadio.Checked = true; break; }
                    case 4: { PeopleGroupRadio.Checked = true; break; }
                }
                

                AdultCountPlaceHolder.Visible = Item.AdultCount > 0;
                InvanvtCountPlaceHolder.Visible = Item.InvantCount > 0;
                LuggageCountPlaceHolder.Visible= Item.LuggageCount > 0;
                StudentsCountPlaceHolder.Visible = Item.StudentCount > 0;
                ChildrenCountPlaceHolder.Visible = Item.ChildrenCount > 0;

                if (Item.Transports.Count>0)
                {
                    if (Item.Transports.Where(t => t.IntCode == 1).Count() > 0) { TransportPlaneCheckbox.Checked = true; }
                    if (Item.Transports.Where(t => t.IntCode == 2).Count() > 0) { TransportTrainCheckbox.Checked = true; }
                    if (Item.Transports.Where(t => t.IntCode == 3).Count() > 0) { TransportBusCheckbox.Checked = true; }
                    if (Item.Transports.Where(t => t.IntCode == 4).Count() > 0) { TransportFerryCheckbox.Checked = true; }
                }

                TransportPriceRefererTextBox.Text = Item.TransportWebsite;

                if (Item.StayPlaces.Count > 0)
                {
                    if (Item.StayPlaces.Where(t => t.IntCode == 1).Count() > 0) { CampingCheckBox.Checked = true; }
                    if (Item.StayPlaces.Where(t => t.IntCode == 2).Count() > 0) { HostelCheckBox.Checked = true; }
                    if (Item.StayPlaces.Where(t => t.IntCode == 3).Count() > 0) { Hotel23CheckBox.Checked = true; }
                    if (Item.StayPlaces.Where(t => t.IntCode == 4).Count() > 0) { Hotel45CheckBox.Checked = true; }
                    if (Item.StayPlaces.Where(t => t.IntCode == 5).Count() > 0) { ApartmentCheckBox.Checked = true; }                    
                }

                RefererWebsiteTextBox.Text = Item.FromWebsite;
                TransportPriceRefererTextBox.Text = Item.TransportWebsite;

                CarRentYesRadio.Checked = Item.CarRental;
                CarRentNoRadio.Checked = !CarRentYesRadio.Checked;
                CarRentCompanyTextBox.Text = Item.CarRentCompany;

                MaxPriceTextBox.Text = Item.TotalPrice.ToString();

                FnameTextBox.Text = Item.Fname;
                LnameTextBox.Text = Item.Lname;
                EmailTextBox.Text = Item.Email;

                AddInfoTextBox.Text = Item.AddInfo;

                ReceiveNewslettersCheckBox.Checked = Item.ReceiveNewsletters;
                ReceiveCommercialInfoCheckbox.Checked = Item.ReceiveCommercialInfo;

            }
            else
            {
                Item = new Offer();
                Response.Redirect("~/");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            var R = new OfferRepository();
            R.DeleteOffer(Item.ID);
            Response.Redirect("~/");
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var M = new Mail();
                //M.Send("mike@63bits.com", "New Website Offer", string.Format("You have new offer from website, please <a href=\"{0}admin/login.aspx?ReturnUrl={0}admin/Offer.aspx?id={1}\">CLICK HERE</a> link below to view details", AppSettings.WebsiteHttpFullPath, Item.ID));
                M.Send("info@bezposoka.bg", "New Website Offer", string.Format("You have new offer from website, please <a href=\"{0}admin/login.aspx?ReturnUrl={0}admin/Offer.aspx?id={1}\">CLICK HERE</a> link below to view details", AppSettings.WebsiteHttpFullPath, Item.ID));
            });
            //Response.Redirect("~/");
            if (Item.OfferTypeCode == 1)
            {
                NewOfferPayPlaceHolder.Visible = true;
            }
            else
            {
                CheckOfferPayPlaceHolder.Visible = true;
            }
        }
    }
}