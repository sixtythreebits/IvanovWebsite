using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Core.Utilities;

namespace Core.Utilities
{
    public class Mail
    {
        #region Properties        
        public bool IsError { set; get; }
        #endregion Properties

        #region Methods
        public void Send(string To, string Subject, string Body, string ReplyTo = null)
        {
            try 
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(AppSettings.EmailSmtpUsername);
                message.To.Add(To);
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;

                if (!string.IsNullOrEmpty(ReplyTo))
                {
                    message.ReplyToList.Add(ReplyTo);
                }

                var client = new SmtpClient(AppSettings.EmailSmtp, AppSettings.EmailSmtpPort)
                {
                    Credentials = new NetworkCredential(AppSettings.EmailSmtpUsername, AppSettings.EmailSmtpPassword),
                    EnableSsl = AppSettings.EmailSmtpEnableSsl,
                    Port = AppSettings.EmailSmtpPort,
                    Timeout = 10
                };
                client.Send(message);
            }
            catch(Exception ex)
            {
                IsError = true;
                string.Format("Send(To = {0}, Subject = {1}, Body = {2}, ReplyTo = {3}) - {4}", To, Subject, Body, ReplyTo, ex.Message).LogString();
            }

        }

        #endregion Methods
    }
}
