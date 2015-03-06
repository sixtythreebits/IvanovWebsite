using System;
using System.Collections.Generic;
using System.Linq;
using Core.DB;

namespace Core
{
    public class DictionaryRepository 
    {

        public static List<DictionaryItem> ListDictionary(int? Level = null, int? DictionaryCode = null, bool? IsVisible = null)
        {
            return ListDictionary(Level, DictionaryCode, IsVisible, false, null);
        }

        public static List<DictionaryItem> ListDictionary(int? Level = null, int? DictionaryCode = null, bool? IsVisible = null, bool WithNullValue = false, string NullValueText = null)
        {
            try
            {
                using (var db = ConnectionFactory.GetDBCoreDataContext())
                {
                    var list = db.List_Dictionaries(Level, DictionaryCode, IsVisible)
                    .OrderBy(d=>d.SortVal).ThenBy(d=>d.Caption)
                    .ToList()
                    .Select(d => new DictionaryItem
                    {
                        ID = d.DictionaryID,
                        Caption = d.Caption,
                        Caption1 = d.Caption1,
                        ParentID = d.ParentID,
                        StringCode = d.StringCode,
                        IntCode = d.IntCode,
                        DictionaryCode = d.DictionaryCode,
                        DefVal = d.DefVal == true,
                        IsVisible = d.Visible == true,
                        SortVal = d.SortVal
                    }).ToList();

                    if (WithNullValue)
                    {
                        list.Insert(0, new DictionaryItem { ID = null, Caption = NullValueText });
                    }

                    return list;
                }
            }
            catch(Exception ex)
            {
                string.Format("ListDictionary(Level = {0}, DictionaryCode = {1}, IsVisible = {2}) - {3}", Level, DictionaryCode, IsVisible, ex.Message);
                return null;
            }
        }
    }

    public class DictionaryItem
    {
        public int? ID { set; get; }
        public string Caption { get; set; }
        public string Caption1 { set; get; }
        public int? ParentID { get; set; }
        public string StringCode { get; set; }
        public int? IntCode { get; set; }
        public short? DictionaryCode { get; set; }
        public bool DefVal { get; set; }
        public bool IsVisible { get; set; }
        public int? SortVal { get; set; }
    }
}
