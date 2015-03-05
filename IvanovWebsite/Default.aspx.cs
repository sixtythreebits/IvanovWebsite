using System;
using System.Linq;
using Core;

namespace IvanovWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitLastOffers();
            InitLastDestinations();
        }

        void InitLastOffers()
        {
            OffersRepeater.DataSource = OfferRepository.ListLastOffers(true).Take(3);
            OffersRepeater.DataBind();
        }

        void InitLastDestinations()
        {
            LastDestinationsRepeater.DataSource = DestinationRepository.ListVisitedDestinations(true).Take(3);
            LastDestinationsRepeater.DataBind();
        }
    }
}