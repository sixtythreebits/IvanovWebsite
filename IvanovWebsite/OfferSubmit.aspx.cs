using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Utilities;
using System.Text;
using System.Xml.Linq;

namespace IvanovWebsite
{
    public partial class OfferSubmit : System.Web.UI.Page
    {
        string OfferType;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            OfferType = Request.QueryString["OfferType"];

            Master.PageTitle = OfferType == "check" ? "Провери оферта" : "Нова оферта";

            if (!IsPostBack)
            {
                HFDateFrom.Value =
                HFDateTo.Value = DateTime.Now.ToString();
            }

            RefererWebsitePlaceHolder.Visible = OfferType == "check";
            MaxPricePerPersonPlaceHolder.Visible = OfferType == "new";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                var R = new OfferRepository();
                var OfferTypeCode = OfferType == "check" ? 2 : 1;
                var TravelersCode = GetSelectedTravelerCode();

                var AdultsCount = AdultsCountCombo.SelectedValue.ToByte();
                var StudentsCount = StudentsCountCombo.SelectedValue.ToByte();
                var LuggageCount = LuggageCountCombo.SelectedValue.ToByte();
                var ChildrenCount = ChildrenCountCombo.SelectedValue.ToByte();
                var InvantCount = InfantCountCombo.SelectedValue.ToByte();



                var OfferID = R.Save(
                    OfferTypeCode: OfferTypeCode,                    
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
                if (R.IsError && OfferID>0)
                {
                    ErrorPlaceHolder.Visible = true;
                }
                else
                {
                    //Session["Success"] = true;
                    //Response.Redirect(string.Format("/offer/{0}/", OfferType));
                    Response.Redirect(string.Format("/offer/review/{0}/", OfferID));
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
