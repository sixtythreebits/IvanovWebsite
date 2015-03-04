using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Core.Utilities;
using System.Xml.Serialization;

namespace Core
{
    public class OfferRepository
    {
        public bool IsError { set; get; }

        public static LastOffer GetSingleLastOffer(int? ID)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    var x = db.GetSingleLastOffer(ID);
                    if (x != null)
                    {
                        return x.ToString().DeserializeTo<LastOffer>();
                    }
                }
            }
            catch (Exception ex)
            {                
                string.Format("GetSingleLastOffer(ID = {0}) - {1}", ID,ex.Message).LogString();                
            }

            return null;
        }

        public static List<LastOffer> ListLastOffers(bool? IsPublished = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_LastOffers(IsPublished)
                    .OrderByDescending(o => o.CRTime)
                    .Select(o => new LastOffer
                    {
                        ID = o.OfferID,
                        ShortDesc = o.ShortDesc,
                        Picture = o.Picture,
                        PdfFile = o.PdfFile,
                        IsPublished = o.IsPublished,
                        CRTime = o.CRTime
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                string.Format("ListLastOffers(IsPublished = {0}) - {1}", IsPublished, ex.Message).LogString();
                return null;
            }
        }

        public void TSP_LastOffer(byte? iud = null, int? ID = null, string Picture = null, string ShortDesc = null, string PdfFile = null, bool? IsPublished = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_LastOffers(iud, ref ID, Picture, ShortDesc, PdfFile, IsPublished);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("TSP_LastOffer(iud = {0}, ID = {1}, Picture = {2}, ShortDesc = {3}, PdfFile = {4}, IsPublished = {5}) - {6}", iud, ID, Picture, ShortDesc, PdfFile, IsPublished, ex.Message).LogString();
            }
        }
    }

    [XmlRoot("Offer")]
    public class LastOffer
    {
        public int? ID { set; get; }
        public string Picture { set; get; }
        public string ShortDesc { set; get; }
        public string PdfFile { set; get; }
        public bool IsPublished { set;get; }
        public DateTime? CRTime { set; get; }
    }
}
