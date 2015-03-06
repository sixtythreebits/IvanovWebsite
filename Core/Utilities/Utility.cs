using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace Core.Utilities
{
    public class Utility
    {
        
    }

    public static class StringExtensions
    {
        public static void LogString(this string StringToLog)
        {
            var WebPage = HttpContext.Current.Request.Url.OriginalString;
            var LogFile = AppSettings.LogFilePath;

            if (!string.IsNullOrEmpty(LogFile) && File.Exists(LogFile))
            {
                File.AppendAllText(LogFile, string.Format("\r\n\r\n------------------------------------\r\n{0} - {1}\r\n{2}\r\n------------------------------------\r\n\r\n", WebPage, DateTime.Now, StringToLog));
            }
        }

        public static string ToAZ09Dash(this string source, bool GuidInlcuded = false, bool Shorten = false)
        {

            if (Shorten)
            {

                var StringLength = source.Length;
                if (StringLength > 15)
                {
                    var ext = Path.GetExtension(source);
                    source = source.Substring(0, 10) + ext;
                }
            }

            return GuidInlcuded ?
                   Regex.Replace(source.Insert(source.LastIndexOf('.'), string.Format("_{0}", Guid.NewGuid().ToString().Substring(0, 8))), @"[^A-Za-z0-9_\.~]+", "_") :
                   Regex.Replace(source, @"[^A-Za-z0-9_\.~]+", "_");
        }

        public static bool? ToBoolean(this string input)
        {
            bool val;
            if (bool.TryParse(input, out val)) return val;
            return null;
        }

        public static byte? ToByte(this string number)
        {
            byte val;
            if (byte.TryParse(number, out val)) return val;
            return null;
        }

        public static DateTime? ToDateTime(this string date)
        {
            DateTime val;
            if (DateTime.TryParse(date, out val)) return val;
            return null;
        }

        public static int? ToInt(this string number)
        {
            int val;
            if (int.TryParse(number, out val)) return val;
            return null;
        }

    }

    public static class ObjectExtensions
    {
        public static T DeserializeTo<T>(this string source)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(source))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
