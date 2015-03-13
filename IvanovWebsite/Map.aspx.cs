using System;
using System.Linq;
using Core;
using Core.Utilities;
using Newtonsoft.Json;

namespace IvanovWebsite
{
    public partial class Map : System.Web.UI.Page
    {
        public int? CurrentID = null;
        public int PageNum = 1;
        int ItemsPerPage = 5;
        int PageCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitStartUp();
        }

        void InitStartUp()
        {
            var list = DestinationRepository.ListVisitedDestinations(true);
            Destination Current = null;
            CurrentID = Request.QueryString["id"].ToInt();

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


            PageCount = (int)Math.Ceiling((decimal)list.Count / (decimal)ItemsPerPage);
            
            InitPager();

            ItemsRepeater.DataSource = list.Skip((PageNum - 1) * ItemsPerPage).Take(ItemsPerPage);
            ItemsRepeater.DataBind();
        }

        void InitPager()
        {
            var x = Request.QueryString["page"].ToInt();
            PageNum = x.HasValue ? x.Value : 1;
            PageNum = PageNum > 1 ? PageNum : 1;

            PagerRepeater.DataSource = Enumerable.Range(1, PageCount);
            PagerRepeater.DataBind();
        }
    }
}