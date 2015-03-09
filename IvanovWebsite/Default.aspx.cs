using System;
using System.Linq;
using Core;
using Core.Utilities;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IvanovWebsite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.Form["action"];
            if (string.IsNullOrWhiteSpace(action))
            {
                InitLastOffers();
                InitLastDestinations();
            }
            else
            {
                ParseBlogFeed();
            }
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

        void ParseBlogFeed()
        {
            try
            {
                Response.Clear();
                using (var client = new WebClient())
                {
                    string reply = client.DownloadString("http://feeds.feedburner.com/Bezposoka");
                    var x = XElement.Parse(reply);
                    var Items = x.Element("channel").Elements("item").Take(3);

                    var BlogItemList = new List<BlogItem>();

                    Items.ToList().ForEach(i =>
                    {
                        var BlogItem = new BlogItem();
                        i.Elements().ToList().ForEach(e =>
                        {                            
                            if (e.Name.ToString().Contains("title")) { BlogItem.Caption = e.Value; }
                            if (e.Name.ToString().Contains("pubDate")) { BlogItem.Date = DateTime.Parse(e.Value).ToString("MMM dd, yyyy"); }
                            if (e.Name.ToString().Contains("link")) { BlogItem.Url = e.Value; }
                            if (e.Name.ToString().Contains("thumbnail")) { BlogItem.Picture = e.Attribute("url").Value; }
                            if (e.Name.ToString().Contains("total")) { BlogItem.CommentsCount = int.Parse(e.Value); }
                        });
                        BlogItemList.Add(BlogItem);
                    });
                    Response.Write(JsonConvert.SerializeObject(BlogItemList, Formatting.None));
                }
            }
            catch(Exception ex)
            {
                ex.Message.LogString();
            }
            finally
            {
                Response.End();
            }
        }
    }
}