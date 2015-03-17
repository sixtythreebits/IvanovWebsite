using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Utilities;
using System.Text;
using System.Xml.Linq;

namespace IvanovWebsite
{
    public partial class OfferEdit : System.Web.UI.Page
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
                Master.PageTitle = Item.OfferTypeCode == 1 ? "Нова оферта" : "Провери оферта";
                MaxPricePerPersonPlaceHolder.Visible = Item.OfferTypeCode == 1;

                if (!IsPostBack)
                {
                    FromLocationTextBox.Text = Item.LocationFrom;
                    ToLocationTextBox.Text = Item.LocationTo;
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

                    FlexDaysStartBeforeCombo.DataBound += (object sender, EventArgs e) =>
                    {
                        var item = FlexDaysStartBeforeCombo.Items.FindByValue(Item.StartFelxBeforeID.ToString());
                        if (item != null) { item.Selected = true; }
                    };
                    FlexDaysStartAfterCombo.DataBound += (object sender, EventArgs e) =>
                    {
                        var item = FlexDaysStartAfterCombo.Items.FindByValue(Item.StartFelxAfterID.ToString());
                        if (item != null) { item.Selected = true; }
                    };
                    FlexDaysEndBeforeCombo.DataBound += (object sender, EventArgs e) =>
                    {
                        var item = FlexDaysEndBeforeCombo.Items.FindByValue(Item.EndFelxBeforeID.ToString());
                        if (item != null) { item.Selected = true; }
                    };
                    FlexDaysEndAfterCombo.DataBound += (object sender, EventArgs e) =>
                    {
                        var item = FlexDaysEndAfterCombo.Items.FindByValue(Item.EndFelxAfterID.ToString());
                        if (item != null) { item.Selected = true; }
                    };


                    switch (Item.TravelersCode)
                    {
                        case 1: { AloneRadio.Checked = true; break; }
                        case 2: { CoupleRadio.Checked = true; break; }
                        case 3: { FamilyRadio.Checked = true; break; }
                        case 4: { PeopleGroupRadio.Checked = true; break; }
                    }

                    var CountComboItem = AdultsCountCombo.Items.FindByValue(Item.AdultCount.ToString());
                    if (CountComboItem != null) { CountComboItem.Selected = true; }
                    CountComboItem = ChildrenCountCombo.Items.FindByValue(Item.AdultCount.ToString());
                    if (CountComboItem != null) { CountComboItem.Selected = true; }
                    CountComboItem = LuggageCountCombo.Items.FindByValue(Item.AdultCount.ToString());
                    if (CountComboItem != null) { CountComboItem.Selected = true; }
                    CountComboItem = StudentsCountCombo.Items.FindByValue(Item.AdultCount.ToString());
                    if (CountComboItem != null) { CountComboItem.Selected = true; }
                    CountComboItem = InfantCountCombo.Items.FindByValue(Item.AdultCount.ToString());
                    if (CountComboItem != null) { CountComboItem.Selected = true; }

                    if (Item.Transports.Count > 0)
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
                    MaxPricePerPersonTextBox.Text = Item.PricePerPerson.ToString();

                    FnameTextBox.Text = Item.Fname;
                    LnameTextBox.Text = Item.Lname;
                    EmailTextBox.Text = Item.Email;
                    NationalityCombo.DataBound += (object sender, EventArgs e) =>
                    {
                        var item = NationalityCombo.Items.FindByValue(Item.NationalityID.ToString());
                        if (item != null) { item.Selected = true; }
                    };

                    AddInfoTextBox.Text = Item.AddInfo;
                    ReceiveNewslettersCheckBox.Checked = Item.ReceiveNewsletters;
                    ReceiveCommercialInfoCheckbox.Checked = Item.ReceiveCommercialInfo;
                }                
            }
            else
            {
                Item = new Offer();
                Response.Redirect("~/");
            }
        }        

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                var R = new OfferRepository();
                var TravelersCode = Request.Form["PeopleGroup"].ToInt();

                var AdultsCount =   AdultsCountCombo.SelectedValue.ToByte();
                var StudentsCount = StudentsCountCombo.SelectedValue.ToByte();
                var LuggageCount =  LuggageCountCombo.SelectedValue.ToByte();
                var ChildrenCount = ChildrenCountCombo.SelectedValue.ToByte();
                var InvantCount = InfantCountCombo.SelectedValue.ToByte();

                R.Update(
                   OfferID:Item.ID,
                   OfferTypeCode: Item.OfferTypeID,
                   LocationFrom: FromLocationTextBox.Text,
                   LocationTo: ToLocationTextBox.Text,
                   StartDate: HFDateFrom.Value.ToDateTime(),
                   EndDate: IsOneWayRadio.Checked ? null : HFDateTo.Value.ToDateTime(),
                   StartFelxBeforeID: FlexDaysStartBeforeCombo.SelectedValue.ToInt(),
                   StartFelxAfterID: FlexDaysStartAfterCombo.SelectedValue.ToInt(),
                   EndFelxBeforeID: IsOneWayRadio.Checked ? null : FlexDaysEndBeforeCombo.SelectedValue.ToInt(),
                   EndFelxAfterID: IsOneWayRadio.Checked ? null : FlexDaysEndAfterCombo.SelectedValue.ToInt(),
                   IsOneWay: IsOneWayRadio.Checked,
                   IsTwoWay: IsTwoWayRadio.Checked,
                   TravelersCode: TravelersCode,
                   AdultCount: AdultsCount,
                   ChildrenCount: ChildrenCount,
                   StudentCount: StudentsCount,
                   InvantCount: InvantCount,
                   LuggageCount: LuggageCount,
                   Transport: GetTransportXml(),
                   TransportWebsite: TransportPriceRefererTextBox.Text,
                   StayPlace: GetStayPlaceXml(),
                   FromWebsite: RefererWebsiteTextBox.Text,
                   CarRental: CarRentYesRadio.Checked,
                   CarRentCompany: CarRentCompanyTextBox.Text,
                   TotalPrice: MaxPriceTextBox.Text.ToInt(),
                   PricePerPerson: MaxPricePerPersonTextBox.Text.ToInt(),
                   CurrencyID: CurrenciesMaxPriceCombo.SelectedValue.ToInt(),
                   Fname: FnameTextBox.Text,
                   Lname: LnameTextBox.Text,
                   Email: EmailTextBox.Text,
                   NationalityID: NationalityCombo.SelectedValue.ToInt(),
                   TimeToResearchID: ResearchTimeCombo.SelectedValue.ToInt(),
                   AddInfo: AddInfoTextBox.Text,
                   ReceiveNewsletters: ReceiveNewslettersCheckBox.Checked,
                   ReceiveCommercialInfo: ReceiveCommercialInfoCheckbox.Checked,
                   AgreeTerms: AgreeTermsOfUseCheckbox.Checked
               );
                if (R.IsError)
                {
                    ErrorPlaceHolder.Visible = true;
                }
                else
                {
                    Response.Redirect(string.Format("/offer/review/{0}/", Item.ID));
                }
            }
        }

        public bool DoValidate()
        {
            if (
                string.IsNullOrWhiteSpace(FromLocationTextBox.Text) ||
                string.IsNullOrWhiteSpace(ToLocationTextBox.Text) ||
                HFDateFrom.Value.ToDateTime() == null ||
                (IsOneWayRadio.Checked == false && HFDateTo.Value.ToDateTime() == null) ||
                GetSelectedTravelerCode() == null ||
                string.IsNullOrWhiteSpace(MaxPriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(FnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(LnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) ||
                NationalityCombo.SelectedIndex < 1
            )
            {
                AllRequiredPlaceHolder.Visible = true;
                return false;
            }
            else if (!AgreeTermsOfUseCheckbox.Checked)
            {
                AgreeToTermsPlaceHolder.Visible = true;
                return false;
            }

            return true;
        }

        XElement GetTransportXml()
        {
            var x = new XElement("data");

            if (TransportPlaneCheckbox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 1)));
            }

            if (TransportTrainCheckbox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 2)));
            }

            if (TransportBusCheckbox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 3)));
            }

            if (TransportFerryCheckbox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 4)));
            }

            return x;
        }

        XElement GetStayPlaceXml()
        {
            var x = new XElement("data");

            if (CampingCheckBox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 1)));
            }

            if (HostelCheckBox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 2)));
            }

            if (Hotel23CheckBox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 3)));
            }

            if (Hotel45CheckBox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 4)));
            }

            if (ApartmentCheckBox.Checked)
            {
                x.Add(new XElement("item", new XElement("id", 5)));
            }

            return x;
        }

        public int? GetSelectedTravelerCode()
        {
            if (AloneRadio.Checked)
            {
                return 1;
            }
            else if (CoupleRadio.Checked)
            {
                return 2;
            }
            else if (FamilyRadio.Checked)
            {
                return 3;
            }
            else if (PeopleGroupRadio.Checked)
            {
                return 4;
            }
            else
            {
                return null;
            }
        }
    }
}
