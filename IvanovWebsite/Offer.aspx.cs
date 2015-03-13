using Core;
using System;
using System.Linq;
using Core.Utilities;
using Core.DB;


namespace IvanovWebsite
{
    public partial class Offer : System.Web.UI.Page
    {
        public List_SubmitedOffersResult Item = new List_SubmitedOffersResult();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            var OfferID = Request.QueryString["id"].ToInt();
            OfferID = 4;
            Item = OfferRepository.ListSubmitedOffers().Where(o => o.OfferID == OfferID).FirstOrDefault();
            if (Item != null)
            {
                FromLocationLiteral.Text = Item.LocationFrom;
                ToLocationLiteral.Text = Item.LocationTo;
                DateFromLiteral.Text = Item.StartDate.HasValue ? Item.StartDate.Value.ToString("yyyy.MM.dd") : null;
                DateToLiteral.Text = Item.EndDate.HasValue ? Item.EndDate.Value.ToString("yyyy.MM.dd") : null;

                DateFromLiteral.Text = string.IsNullOrWhiteSpace(Item.StartFelxBefore) ? DateFromLiteral.Text : string.Format("{0}&nbsp;&nbsp;  {1}", DateFromLiteral.Text, Item.StartFelxBefore);
                DateFromLiteral.Text = string.IsNullOrWhiteSpace(Item.StartFelxAfter) ? DateFromLiteral.Text : string.Format("{0},  {1}", DateFromLiteral.Text, Item.StartFelxAfter);

                DateToLiteral.Text = string.IsNullOrWhiteSpace(Item.EndFelxBefore) ? DateToLiteral.Text : string.Format("{0}&nbsp;&nbsp;  {1}", DateToLiteral.Text, Item.StartFelxBefore);
                DateToLiteral.Text = string.IsNullOrWhiteSpace(Item.EndFelxAfter) ? DateToLiteral.Text : string.Format("{0},  {1}", DateToLiteral.Text, Item.EndFelxAfter);

                
                if (Item.Travelers =="Самостоятелно") { AloneRadio.Checked = true; }
                if (Item.Travelers == "Двойка") { CoupleRadio.Checked = true; }
                if (Item.Travelers == "Семейство") { FamilyRadio.Checked = true; }
                if (Item.Travelers =="Група") { PeopleGroupRadio.Checked = true; }

                AdultCountPlaceHolder.Visible = Item.AdultCount > 0;
                InvanvtCountPlaceHolder.Visible = Item.InvantCount > 0;
                LuggageCountPlaceHolder.Visible= Item.LuggageCount > 0;
                StudentsCountPlaceHolder.Visible = Item.StudentCount > 0;
                ChildrenCountPlaceHolder.Visible = Item.ChildrenCount > 0;

                if (!string.IsNullOrWhiteSpace(Item.Transport))
                {
                    if (Item.Transport.Contains("Самолет")) { TransportPlaneCheckbox.Checked = true; }
                    if (Item.Transport.Contains("Влак")) { TransportTrainCheckbox.Checked = true; }
                    if (Item.Transport.Contains("Автобус")) { TransportBusCheckbox.Checked = true; }
                    if (Item.Transport.Contains("Ферибот")) { TransportFerryCheckbox.Checked = true; }
                }

                TransportPriceRefererTextBox.Text = Item.TransportWebsite;

                if (!string.IsNullOrWhiteSpace(Item.StayPlace))
                {
                    if (Item.StayPlace.Contains("Къмпинг")) { CampingCheckBox.Checked = true; }
                    if (Item.StayPlace.Contains("Хостел")) { HostelCheckBox.Checked = true; }
                    if (Item.StayPlace.Contains("Хотел 2-3")) { Hotel23CheckBox.Checked = true; }
                    if (Item.StayPlace.Contains("Хотел 4-5")) { Hotel45CheckBox.Checked = true; }
                    if (Item.StayPlace.Contains("Студио / Апартамент")) { ApartmentCheckBox.Checked = true; }
                }

                RefererWebsiteTextBox.Text = Item.FromWebsite;
                TransportPriceRefererTextBox.Text = Item.TransportWebsite;

                CarRentYesRadio.Checked = Item.CarRental;
                CarRentNoRadio.Checked = !CarRentYesRadio.Checked;
                CarRentCompanyTextBox.Text = Item.CarRentCompany;

                MaxPriceTextBox.Text = Item.TotalPrice.ToString();
                MaxPricePerPersonTextBox.Text = Item.PricePerPerson.ToString();

                FnameTextBox.Text = Item.Fname;
                LnameTextBox.Text = Item.Lname;
                EmailTextBox.Text = Item.Email;

                AddInfoTextBox.Text = Item.AddInfo;

                ReceiveNewslettersCheckBox.Checked = Item.ReceiveNewsletters;
                ReceiveCommercialInfoCheckbox.Checked = Item.ReceiveCommercialInfo;

            }
            else
            {

            }
        }
    }
}