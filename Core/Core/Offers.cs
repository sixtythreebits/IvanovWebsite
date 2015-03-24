using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Core.Utilities;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Core
{
    public class OfferRepository
    {
        public bool IsError { set; get; }

        public void DeleteOffer(int? ID)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.DeleteOffer(ID);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("DeleteOffer(ID = {0}) - {1}", ID, ex.Message);
            }

        }

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

        public static Offer GetSingleOffer(int? ID)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    var x = db.GetSingleOffer(ID);
                    if (x == null)
                    {
                        return null;
                    }
                    else
                    {
                        return x.ToString().DeserializeTo<Offer>();
                    }
                }
            }
            catch (Exception ex)
            {
                string.Format("GetSingleOffer(ID = {0}) - {1}", ID, ex.Message).LogString();
                return null;                
            }
        }

        public static List<OfferComment> ListOfferComments(int? OfferID = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_OfferComments(OfferID)
                    .OrderByDescending(c => c.CRTime)
                    .Select(c => new OfferComment
                    {
                        ID = c.CommentID,
                        Fullname = c.Fullname,
                        Comment = c.Comment,
                        CRTime = c.CRTime
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                string.Format("ListOfferComments(OfferID = {0}) - {1}", OfferID, ex.Message).LogString();
                return null;
            }
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

        public static List<Offer> ListSubmitedOffers()
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_SubmitedOffers()
                    .OrderByDescending(o => o.CRTime)
                    .Select(o => new Offer
                    {
                        ID = o.OfferID,
                        OfferType = o.OfferType,
                        LocationFrom = o.LocationFrom,
                        LocationTo = o.LocationTo,
                        Fullname = o.Fullname,
                        ManagersString = o.ManagersString,
                        ExpDate = o.ExpDate,
                        CRTime = o.CRTime
                    }).ToList();
                }
            }
            catch(Exception ex)
            {
                string.Format("ListSubmitedOffers() - {0}",ex.Message).LogString();
                return null;
            }
        }

        public int? Save(int? OfferTypeCode, string LocationFrom, string LocationTo, DateTime? StartDate, DateTime? EndDate, int? StartFelxBeforeID, int? StartFelxAfterID, int? EndFelxBeforeID, int? EndFelxAfterID, bool? IsOneWay, bool? IsTwoWay, int? TravelersCode, byte? AdultCount, byte? ChildrenCount, byte? StudentCount, byte? InvantCount, byte? LuggageCount, XElement Transport, string TransportWebsite, XElement StayPlace, string FromWebsite, bool? CarRental, string CarRentCompany, int? TotalPrice, int? PricePerPerson, int? CurrencyID, string Fname, string Lname, string Email, int? NationalityID, int? TimeToResearchID, string AddInfo, bool? ReceiveNewsletters, bool? ReceiveCommercialInfo, bool? AgreeTerms)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    int? OfferID = null;
                    db.SaveOffer(OfferTypeCode, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, Transport, TransportWebsite, StayPlace, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, AgreeTerms, ref OfferID);
                    return OfferID;
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("Save(OfferTypeCode = {0}, LocationFrom = {1}, LocationTo = {2}, StartDate = {3}, EndDate = {4}, StartFelxBeforeID = {5}, StartFelxAfterID = {6}, EndFelxBeforeID = {7}, EndFelxAfterID = {8}, IsOneWay = {9}, IsTwoWay = {10}, TravelersCode = {11}, AdultCount = {12}, ChildrenCount = {13}, StudentCount = {14}, InvantCount = {15}, LuggageCount = {16}, Transport = {17}, TransportWebsite = {18}, StayPlace = {19}, FromWebsite = {20}, CarRental = {21}, CarRentCompany = {22}, TotalPrice = {23}, PricePerPerson = {24}, CurrencyID = {25}, Fname = {26}, Lname = {27}, Email = {28}, NationalityID = {29}, TimeToResearchID = {30}, AddInfo = {31}, ReceiveNewsletters = {32}, ReceiveCommercialInfo = {33}, AgreeTerms = {34}) - {35}", OfferTypeCode, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, Transport, TransportWebsite, StayPlace, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, AgreeTerms,ex.Message);
            }

            return null;
        }

        public void Update(int? OfferID,int? OfferTypeCode, string LocationFrom, string LocationTo, DateTime? StartDate, DateTime? EndDate, int? StartFelxBeforeID, int? StartFelxAfterID, int? EndFelxBeforeID, int? EndFelxAfterID, bool? IsOneWay, bool? IsTwoWay, int? TravelersCode, byte? AdultCount, byte? ChildrenCount, byte? StudentCount, byte? InvantCount, byte? LuggageCount, XElement Transport, string TransportWebsite, XElement StayPlace, string FromWebsite, bool? CarRental, string CarRentCompany, int? TotalPrice, int? PricePerPerson, int? CurrencyID, string Fname, string Lname, string Email, int? NationalityID, int? TimeToResearchID, string AddInfo, bool? ReceiveNewsletters, bool? ReceiveCommercialInfo, bool? AgreeTerms)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {                    
                    db.UpdateOffer(OfferID,OfferTypeCode, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, Transport, TransportWebsite, StayPlace, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, AgreeTerms);                    
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("Update(OfferID = {0}, OfferTypeCode = {1}, LocationFrom = {2}, LocationTo = {3}, StartDate = {4}, EndDate = {5}, StartFelxBeforeID = {6}, StartFelxAfterID = {7}, EndFelxBeforeID = {8}, EndFelxAfterID = {9}, IsOneWay = {10}, IsTwoWay = {11}, TravelersCode = {12}, AdultCount = {13}, ChildrenCount = {14}, StudentCount = {15}, InvantCount = {16}, LuggageCount = {17}, Transport = {18}, TransportWebsite = {19}, StayPlace = {20}, FromWebsite = {21}, CarRental = {22}, CarRentCompany = {23}, TotalPrice = {24}, PricePerPerson = {25}, CurrencyID = {26}, Fname = {27}, Lname = {28}, Email = {29}, NationalityID = {30}, TimeToResearchID = {31}, AddInfo = {32}, ReceiveNewsletters = {33}, ReceiveCommercialInfo = {34}, AgreeTerms = {35}) - {36}", OfferID, OfferTypeCode, LocationFrom, LocationTo, StartDate, EndDate, StartFelxBeforeID, StartFelxAfterID, EndFelxBeforeID, EndFelxAfterID, IsOneWay, IsTwoWay, TravelersCode, AdultCount, ChildrenCount, StudentCount, InvantCount, LuggageCount, Transport, TransportWebsite, StayPlace, FromWebsite, CarRental, CarRentCompany, TotalPrice, PricePerPerson, CurrencyID, Fname, Lname, Email, NationalityID, TimeToResearchID, AddInfo, ReceiveNewsletters, ReceiveCommercialInfo, AgreeTerms, ex.Message);
            }            
        }

        public void TSP_OfferManagers(byte? iud = null, int? ID = null,int? OfferID = null, int? ManagerID = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_OfferManagers(iud, ref ID, OfferID, ManagerID);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("UpdateOfferManager(OfferID = {0}, ManagerID = {1}) - {2}", OfferID, ManagerID, ex.Message);
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

        public void TSP_OfferComments(byte? iud = null, int? ID = null, string Comment = null, int? UserID = null, int? OfferID = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_OfferComments(iud, ref ID, UserID, OfferID, Comment);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("TSP_OfferComments(iud = {0}, ID = {1}, Comment = {2}, UserID = {3}, OfferID = {4}) - {5}", iud, ID, Comment, UserID, OfferID, ex.Message).LogString();
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

    public class Offer
    {
        #region Properties
        public int ID { set; get; }
        public int? OfferTypeID { set; get; }
        public DateTime? ExpDate { set; get; }
        public int? OfferTypeCode { set; get; }
        public string OfferType { set; get; }
        public string LocationFrom{ set; get; }
        public string LocationTo { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public int? StartFelxBeforeID { set; get; }
        public string StartFelxBefore { set; get; }
        public int? StartFelxAfterID { set; get; }
        public string StartFelxAfter { set; get; }
        public int? EndFelxBeforeID { set; get; }
        public string EndFelxBefore { set; get; }
        public int? EndFelxAfterID { set; get; }
        public string EndFelxAfter { set; get; }
        public bool IsOneWay { set; get; }
        public bool IsTwoWay { set; get; }
        public int? TravelersID { set; get; }
        public string Travelers { set; get; }
        public int? TravelersCode { set; get; }
        public byte? AdultCount { set; get; }
        public byte? ChildrenCount { set; get; }
        public byte? StudentCount { set; get; }
        public byte? InvantCount { set; get; }
        public byte? LuggageCount { set; get; }
        public string TransportWebsite { set; get; }
        public string FromWebsite { set; get; }
        public bool CarRental { set; get; }
        public string CarRentCompany { set; get; }
        public int? TotalPrice { set; get; }
        public int? PricePerPerson { set; get; }
        public int? CurrencyID { set; get; }
        public string Currency { set; get; }
        public string Fullname { set; get; }
        public string Fname { set; get; }
        public string Lname { set; get; }
        public string Email { set; get; }
        public int? NationalityID { set; get; }
        public string Nationality { set; get; }
        public int? TimeToResearchID { set; get; }
        public string TimeToResearch { set; get; }
        public string AddInfo { set; get; }
        public bool ReceiveNewsletters { set; get; }
        public bool ReceiveCommercialInfo { set; get; }
        public bool AgreeTerms { set; get; }
        public string ManagersString { set; get; }
        [XmlArray("OfferManagers")]
        public List<OfferManager> OfferManagers { set; get; }
        public DateTime CRTime { set; get; }
        [XmlArray("StayPlaces")]
        public List<DictionaryItem> Transports { set; get; }
        [XmlArray("Transports")]
        public List<DictionaryItem> StayPlaces { set; get; }
        #endregion Properties
    }

    public class OfferComment
    {
        public int? ID { set; get; }
        public string Fullname { set; get; }
        public string Comment { set; get; }
        public DateTime? CRTime { set; get; }
    }

    public class OfferManager
    {
        public int? ID { set; get; }
        public string Fullname { set; get; }
    }
}
