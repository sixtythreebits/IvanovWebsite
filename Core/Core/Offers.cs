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
                        Caption = o.Caption,
                        Location = o.Location,
                        ShortDesc = o.ShortDesc,
                        Picture = o.Picture,
                        PdfFile = o.PdfFile,
                        UsersCount = o.UsersCount,
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

        public static List<List_SubmitedOffersResult> ListSubmitedOffers()
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_SubmitedOffers().OrderByDescending(o => o.CRTime).ToList();
                }
            }
            catch(Exception ex)
            {
                string.Format("ListSubmitedOffers() - {0}",ex.Message).LogString();
                return null;
            }
        }

        public void Save(int? OfferTypeCode, int? LocationFromID, int? LocationToID, string LocationFrom, string LocationTo, DateTime? StartDate, DateTime? EndDate, int? StartFelxBeforeID, int? StartFelxAfterID, int? EndFelxBeforeID, int? EndFelxAfterID, bool? IsOneWay, bool? IsTwoWay, int? TravelersCode, byte? AdultCount, byte? ChildrenCount, byte? StudentCount, byte? InvantCount, byte? LuggageCount, int? TransportCode,string Transport,string TransportWebsite, int? StayPlaceCode, string FromWebsite, bool? CarRental,string CarRentCompany, int? TotalPrice, int? PricePerPerson, int? CurrencyID, string Fname, string Lname, string Email, int? NationalityID, int? TimeToResearchID, string AddInfo, bool? ReceiveNewsletters, bool? ReceiveCommercialInfo, bool? AgreeTerms)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.SaveOffer(OfferTypeCode, LocationFromID, LocationToID, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, TransportCode, Transport, TransportWebsite, StayPlaceCode, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, AgreeTerms);
                }
            }
            catch(Exception ex)
            { 
                IsError = true;
                string.Format("Save(OfferTypeCode = {0}, LocationFromID = {1}, LocationToID = {2}, LocationFrom = {3}, LocationTo = {4}, StartDate = {5}, EndDate = {6}, StartFelxBeforeID = {7}, StartFelxAfterID = {8}, EndFelxBeforeID = {9}, EndFelxAfterID = {10}, IsOneWay = {11}, IsTwoWay = {12}, TravelersCode = {13}, AdultCount = {14}, ChildrenCount = {15}, StudentCount = {16}, InvantCount = {17}, LuggageCount = {18}, TransportCode = {19}, Transport = {20}, TransportWebsite = {21}, StayPlaceCode = {22}, FromWebsite = {23}, CarRental = {24}, CarRentCompany = {25}, TotalPrice = {26}, PricePerPerson = {27}, CurrencyID = {28}, Fname = {29}, Lname = {30}, Email = {31}, NationalityID = {32}, TimeToResearchID = {33}, AddInfo = {34}, ReceiveNewsletters = {35}, ReceiveCommercialInfo = {36}, AgreeTerms = {37}) - {38}", OfferTypeCode, LocationFromID, LocationToID, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, TransportCode, Transport, TransportWebsite, StayPlaceCode, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, ex.Message).LogString();
            }
        }

        public void TSP_LastOffer(byte? iud = null, int? ID = null, string Caption = null, string Location = null, string Picture = null, string ShortDesc = null, string PdfFile = null, int? UsersCount = null, bool? IsPublished = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_LastOffers(iud, ref ID, Caption, Location, ShortDesc, Picture, PdfFile, UsersCount, IsPublished);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("TSP_LastOffer(iud = {0}, ID = {1}, Caption = {2}, Location = {3}, Picture = {4}, ShortDesc = {5}, PdfFile = {6}, UsersCount = {7}, IsPublished = {8}) - {9}", iud, ID, Caption, Location, Picture, ShortDesc, PdfFile, UsersCount, IsPublished, ex.Message).LogString();
            }
        }
    }

    [XmlRoot("Offer")]
    public class LastOffer
    {
        public int? ID { set; get; }
        public string Caption { set; get; }
        public string Location { set; get; }
        public string Picture { set; get; }
        public string ShortDesc { set; get; }
        public string PdfFile { set; get; }
        public int? UsersCount { set; get; }
        public bool IsPublished { set;get; }
        public DateTime? CRTime { set; get; }
    }
}
