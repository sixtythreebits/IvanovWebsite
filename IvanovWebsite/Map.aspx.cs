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
                HFCurrentMarker.Value = JsonConvert.SerializeObject(new { lat = Current.Lat, lng = Current.Lng, text = Current.ShortDesc, image = string.Format("/uploads/{0}?width=160&height=111", Current.Picture) });
                HFMarkers.Value = JsonConvert.SerializeObject(list.Select(i => new { lat = i.Lat, lng = i.Lng, text = i.ShortDesc.Shorten(100), image = string.Format("/uploads/{0}?width=160&height=111", i.Picture) }), Formatting.None);
                list.Insert(0, Current);
            }
            else
            {
                HFMarkers.Value = JsonConvert.SerializeObject(list.Select(i => new { lat = i.Lat, lng = i.Lng, text = i.ShortDesc.Shorten(100), image = string.Format("/uploads/{0}?width=160&height=111", i.Picture) }), Formatting.None);
            }

            ItemsRepeater.DataSource = list;
            ItemsRepeater.DataBind();
        }
    }
}