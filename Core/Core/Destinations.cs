using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Core.Utilities;
using System.Xml.Serialization;

namespace Core
{
    public class DestinationRepository
    {
        public bool IsError { set; get; }

        public static Destination GetSingleVisitedDestination(int? ID)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    var x = db.GetSingleVisitedDestination(ID);
                    if (x != null)
                    {
                        return x.ToString().DeserializeTo<Destination>();
                    }
                }
            }
            catch (Exception ex)
            {
                string.Format("GetSingleVisitedDestination(ID = {0}) - {1}", ID, ex.Message).LogString();
            }

            return null;
        }

        public static List<Destination> ListVisitedDestinations(bool? IsPublished = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_VisitedDestinations(IsPublished)
                    .OrderByDescending(d => d.CRTime)
                    .Select(d => new Destination
                    {
                        ID = d.DestinationID,
                        Caption = d.Caption,
                        ShortDesc = d.ShortDesc,
                        Picture = d.Picture,
                        Lat = d.Lat,
                        Lng = d.Lng,
                        IsPublished = d.IsPublished,
                        CRTime = d.CRTime
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                string.Format("ListVisitedDestinations(ListLastOffers = {0}) - {1}", IsPublished, ex.Message).LogString();
                return null;
            }
        }

        public void TSP_VisitedDestination(byte? iud = null, int? ID = null, string Caption = null, string Picture = null, string ShortDesc = null, string Lat = null, string Lng = null, bool? IsPublished = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_VisitedDestinations(iud, ref ID, Caption, Picture, ShortDesc, Lat, Lng, IsPublished);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("TSP_VisitedDestination(iud = {0}, ID = {1}, Caption = {2}, Picture = {3}, ShortDesc = {4}, Lat = {5}, Lng = {6}, IsPublished = {7}) - {8}", iud, ID, Caption, Picture, ShortDesc, Lat, Lng, IsPublished, ex.Message);
            }
        }
    }

    public class Destination
    {
        public int? ID { set; get; }
        public string Caption { set; get; }
        public string Picture { set; get; }
        public string ShortDesc { set; get; }
        public string Lat { set; get; }
        public string Lng { set; get; }
        public bool IsPublished { set; get; }
        public DateTime? CRTime { set; get; }
    }
}
