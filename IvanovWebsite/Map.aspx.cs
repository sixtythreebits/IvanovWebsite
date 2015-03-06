using System;
using System.Linq;
using Core;
using Core.Utilities;
using Newtonsoft.Json;

namespace IvanovWebsite
{
    public partial class Map : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            var list = DestinationRepository.ListVisitedDestinations(true);
            Destination Current = null;
            var CurrentID = Request.QueryString["id"].ToInt();
            if (CurrentID > 0)
            {
                Current = list.Where(d => d.ID == CurrentID).FirstOrDefault();
                list.Remove(Current);
                HFCurrentLat.Value = Current.Lat;
                HFCurrentLng.Value = Current.Lng;
                HFMarkers.Value = JsonConvert.SerializeObject(list.Select(i => new { lat = i.Lat, lng = i.Lng }), Formatting.None);
                list.Insert(0, Current);
            }
            else
            {
                HFMarkers.Value = JsonConvert.SerializeObject(list.Select(i => new { lat = i.Lat, lng = i.Lng }), Formatting.None);
            }

            ItemsRepeater.DataSource = list;
            ItemsRepeater.DataBind();
        }
    }
}