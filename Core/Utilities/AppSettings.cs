using System.Configuration;
using System.Web;

namespace Core.Utilities
{
    public class AppSettings
    {
        public static string EmailSmtp
        {
            get { return ConfigurationManager.AppSettings["EmailSmtp"]; }
        }

        public static string EmailSmtpUsername
        {
            get { return ConfigurationManager.AppSettings["EmailSmtpUsername"]; }
        }

        public static string EmailSmtpPassword
        {
            get { return ConfigurationManager.AppSettings["EmailSmtpPassword"]; }
        }

        public static int EmailSmtpPort
        {
            get { return int.Parse(ConfigurationManager.AppSettings["EmailSmtpPort"]); }
        }

        public static bool EmailSmtpEnableSsl
        {
            get { return ConfigurationManager.AppSettings["EmailSmtpEnableSsl"] == "true"; }
        }

        public static string LogFilePath
        {
            get { return string.Format("{0}\\App_data\\ErrorLog.txt", HttpRuntime.AppDomainAppPath); }
        }

        public static string UploadFilePhysicalPath
        {
            get { return string.Format("{0}\\uploads\\", HttpRuntime.AppDomainAppPath); }
        }

        public static string UploadFileHttpPath
        {
            get { return "/uploads/"; }
        }

        public static string WebsiteHttpFullPath
        {
            get { return ConfigurationManager.AppSettings["WebsiteHttpFullPath"]; }
        }
    }
}
