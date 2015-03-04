using System.Web;

namespace Core.Utilities
{
    public class AppSettings
    {
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
    }
}
