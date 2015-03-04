using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;
using Core.Utilities;
using System.Xml.Serialization;
using System.Web;

namespace Core
{
    public class UsersRepository
    {
        public bool IsError { set; get; }

        public static User AuthenticateUser(string Username, string Password, bool WriteToSession = true)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    var x = db.GetAuthenticatedUser(Username, Password);
                    if (x != null)
                    {
                        var U = x.ToString().DeserializeTo<User>();
                        U.IsAuthenticated = true;
                        if (WriteToSession)
                        {
                            HttpContext.Current.Session["UserObject"] = U;
                        }
                        return U;
                    }
                }
            }
            catch (Exception ex)
            {
                string.Format("AuthenticateUser(Username = {0}, Password = {1}) - {2}", Username, ex.Message).LogString();
            }

            return null;
        }

        public static User GetFromSession()
        {
            return HttpContext.Current.Session["UserObject"] as User;            
        }

        public static List<User> ListUsers()
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    return db.List_Users()
                    .OrderByDescending(u => u.CRTime)
                    .Select(u => new User
                    {
                        ID = u.UserID,
                        Email = u.Email,
                        Fname = u.Fname,
                        Lname = u.Lname,
                        Fullname = u.Fname,
                        IsActive = u.IsActive,
                        RoleID = u.RoleID,
                        CRTime = u.CRTime
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                string.Format("ListLastOffers(ListUsers) - {0}", ex.Message).LogString();
                return null;
            }
        }

        public void TSP_Users(byte? iud = null, int? ID = null, string Email = null, string Password = null, string Fname = null, string Lname = null, bool? IsActive = null, int? RoleID = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    db.tsp_Users(iud, ref ID, RoleID, Email, Password, Fname, Lname, IsActive);
                }
            }
            catch (Exception ex)
            {
                IsError = true;
                string.Format("TSP_Users(iud = {0}, ID = {1}, Email = {2}, Password = {3}, Fname = {4}, Lname = {5}, IsActive = {6}, RoleID = {7}) - {8}", iud, ID, Email, Password, Fname, Lname, IsActive, RoleID, ex.Message).LogString(); 
            }
        }
    }

    [Serializable]
    public class User
    {
        public int? ID { set; get; }
        public int? RoleID { set; get; }
        public int? RoleCode { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Fname { set; get; }
        public string Lname { set; get; }
        public string Fullname { set; get; }
        public bool IsActive { set; get; }
        public bool IsAuthenticated { set; get; }
        public DateTime? CRTime { set; get; }
    }
}
