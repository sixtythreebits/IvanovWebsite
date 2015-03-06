using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.Utilities;

namespace IvanovWebsite
{
    public partial class OfferSubmit : System.Web.UI.Page
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
            if (AgreeTermsOfUseCheckbox.Checked)
            {
                var R = new OfferRepository();
                var OfferTypeCode = OfferType == "check" ? 2 : 1;
                var TravelersCode = Request.Form["TransportGroup"].ToInt();

                var AdultsCount = TravelersCode == 1 ? AdultsCountCombo.SelectedValue.ToByte() : (TravelersCode == 3 ? AdultsCountCombo1.SelectedValue.ToByte() : null);
                var StudentsCount = TravelersCode == 1 ? StudentsCountCombo.SelectedValue.ToByte() : (TravelersCode == 3 ? StudentsCountCombo1.SelectedValue.ToByte() : null);
                var LuggageCount = TravelersCode == 1 ? LuggageCountCombo.SelectedValue.ToByte() : (TravelersCode == 3 ? LuggageCountCombo1.SelectedValue.ToByte() : null);
                var ChildrenCount = TravelersCode == 3 ? ChildrenCountCombo.SelectedValue.ToByte() : null;
                var InvantCount = TravelersCode == 3 ? InfantCountCombo.SelectedValue.ToByte() : null;

                R.Save(
                    OfferTypeCode: OfferTypeCode,
                    LocationFromID: FromLocationCombo.SelectedValue.ToInt(),
                    LocationToID: ToLocationCombo.SelectedValue.ToInt(),
                    StartDate: HFDateFrom.Value.ToDateTime(),
                    EndDate: HFDateTo.Value.ToDateTime(),
                    StartFelxBeforeID: FlexDaysStartBeforeCombo.SelectedValue.ToInt(),
                    StartFelxAfterID: FlexDaysStartAfterCombo.SelectedValue.ToInt(),
                    EndFelxBeforeID: FlexDaysEndBeforeCombo.SelectedValue.ToInt(),
                    EndFelxAfterID: FlexDaysEndAfterCombo.SelectedValue.ToInt(),
                    IsOneWay: IsOneWayCheckBox.Checked,
                    IsTwoWay: IsTwoWayCheckbox.Checked,
                    TravelersCode: TravelersCode,
                    AdultCount: AdultsCount,
                    ChildrenCount: ChildrenCount,
                    StudentCount: StudentsCount,
                    InvantCount: InvantCount,
                    LuggageCount: LuggageCount,
                    TransportCode: Request.Form["TransportGroup"].ToInt(),
                    StayPlaceCode: Request.Form["StayPlaceGroup"].ToInt(),
                    FromWebsite: RefererWebsiteTextBox.Text,
                    CarRental: CarRentYesRadio.Checked,
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
                    Session["Success"] = true;
                    Response.Redirect(string.Format("/offer/{0}/#success-message", OfferType));
                }
            }
            else
            {
                AgreeToTermsPlaceHolder.Visible = true;
            }
        }
    }
}
