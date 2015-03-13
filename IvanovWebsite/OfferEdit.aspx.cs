using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Utilities;
using System.Text;

namespace IvanovWebsite
{
    public partial class OfferEdit : System.Web.UI.Page
    {
        string OfferType;
        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
            CheckSession();
        }

        void CheckSession()
        {
            if (Session["Success"] != null)
            {
                Session.Remove("Success");
                FormPlaceHolder.Visible = false;
                FormScriptsPlaceHolder.Visible = false;
                SuccessPlaceHolder.Visible = true;
            }
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
                var TravelersCode = Request.Form["PeopleGroup"].ToInt();

                var AdultsCount = (TravelersCode == 1 || TravelersCode == 2) ? AdultsCountCombo.SelectedValue.ToByte() : ((TravelersCode == 3 || TravelersCode == 4) ? AdultsCountCombo1.SelectedValue.ToByte() : null);
                var StudentsCount = (TravelersCode == 1 || TravelersCode == 2) ? StudentsCountCombo.SelectedValue.ToByte() : ((TravelersCode == 3 || TravelersCode == 4) ? StudentsCountCombo1.SelectedValue.ToByte() : null);
                var LuggageCount = (TravelersCode == 1 || TravelersCode == 2) ? LuggageCountCombo.SelectedValue.ToByte() : ((TravelersCode == 3 || TravelersCode == 4) ? LuggageCountCombo1.SelectedValue.ToByte() : null);
                var ChildrenCount = (TravelersCode == 3 || TravelersCode == 4) ? ChildrenCountCombo.SelectedValue.ToByte() : null;
                var InvantCount = (TravelersCode == 3 || TravelersCode == 4) ? InfantCountCombo.SelectedValue.ToByte() : null;



                var OfferID = R.Save(
                    OfferTypeCode: OfferTypeCode,
                    //LocationFromID: FromLocationCombo.SelectedValue.ToInt(),
                    //LocationToID: ToLocationCombo.SelectedValue.ToInt(),
                    LocationFromID: null,
                    LocationToID: null,
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
                    TransportCode: Request.Form["TransportGroup"].ToInt(),
                    Transport: GetTransportString(),
                    TransportWebsite: TransportPriceRefererTextBox.Text,
                    StayPlaceCode: Request.Form["StayPlaceGroup"].ToInt(),
                    StayPlace: GetStayPlaceString(),
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
                if (R.IsError && OfferID > 0)
                {
                    ErrorPlaceHolder.Visible = true;
                }
                else
                {
                    //Session["Success"] = true;
                    //Response.Redirect(string.Format("/offer/{0}/", OfferType));
                    Response.Redirect(string.Format("/offer/{0}/", OfferID));
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
                Request.Form["PeopleGroup"].ToInt() == null ||                                
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

        string GetTransportString()
        {
            var sb = new StringBuilder();
            if (TransportPlaneCheckbox.Checked)
            {
                sb.Append("Самолет,");
            }

            if (TransportTrainCheckbox.Checked)
            {
                sb.Append("Влак,");
            }

            if (TransportBusCheckbox.Checked)
            {
                sb.Append("Автобус,");
            }

            if (TransportFerryCheckbox.Checked)
            {
                sb.Append("Ферибот");
            }

            return sb.ToString().TrimEnd(',');
        }

        string GetStayPlaceString()
        {
            var sb = new StringBuilder();
            if (CampingCheckBox.Checked)
            {
                sb.Append("Къмпинг,");
            }

            if (HostelCheckBox.Checked)
            {
                sb.Append("Хостел,");
            }

            if (Hotel23CheckBox.Checked)
            {
                sb.Append("Хотел 2-3,");
            }

            if (Hotel45CheckBox.Checked)
            {
                sb.Append("Хотел 4-5");
            }

            if (ApartmentCheckBox.Checked)
            {
                sb.Append("Студио / Апартамент");
            }

            return sb.ToString().TrimEnd(',');
        }
    }
}
