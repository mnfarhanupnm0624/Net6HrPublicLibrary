using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Net6HrPublicLibrary.PublicShared
{
    public class EmailHelper
    {
        static string _encryptCode = System.Configuration.ConfigurationManager.AppSettings["encryptCode"];

        public static string SendEmail(string emailFrom, string emailTo, string emailSubject, string emailMessage)
        {
            string _return = "";
            try
            {
                var senderEmail = new MailAddress(emailFrom, "UPNM-HR Admin");
                var receiverEmail = new MailAddress(emailTo, "Receiver");
                var password = "<YourOutlookPassword>";
                var sub = emailSubject;
                var body = emailMessage;
                var smtp = new System.Net.Mail.SmtpClient
                {
                    //Host = "smtp.outlook.com",
                    Host = "smtp-relay.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                _return = "Success send eEmail to " + emailTo;
            }
            catch (Exception ex)
            {
                _return = "Error SendEmail TryCatch : " + ex;
            }
            return _return;
        }

        public static string OutlookSendEmail(string emailFrom, string emailTo, string emailSubject, string emailMessage, string gmailAuthenticateEmail, string gmailAuthenticatePassword)
        {
            //var log = NLog.LogManager.GetCurrentClassLogger();
            //log.Info("OutlookSendEmail emailFrom ~ " + emailFrom);
            //log.Info("OutlookSendEmail emailTo ~ " + emailTo);
            //log.Info("OutlookSendEmail emailSubject ~ " + emailSubject);
            //log.Info("OutlookSendEmail emailMessage ~ " + emailMessage);
            //log.Info("OutlookSendEmail gmailAuthenticateEmail ~ " + gmailAuthenticateEmail);
            //log.Info("OutlookSendEmail gmailAuthenticatePassword ~ " + gmailAuthenticatePassword);

            string _authenticateEmail = EncryptHr.DecryptString4url(gmailAuthenticateEmail, "admSmis");
            string _authenticatePaswd = EncryptHr.DecryptString4url(gmailAuthenticatePassword, "admSmis");

            //log.Info("OutlookSendEmail emailTo ~ " + emailTo);
            //log.Info("OutlookSendEmail _authenticateEmail ~ " + _authenticateEmail);
            //log.Info("OutlookSendEmail _authenticatePaswd ~ " + _authenticatePaswd);
            //emailTo = "zaman@utm.my";

            string _return = "";
            try
            {
                var authenticateSenderEmail = new MailAddress(_authenticateEmail, "Sender");
                var senderEmail = new MailAddress(_authenticateEmail, "UPNM-Visa Admin");
                var receiverEmail = new MailAddress(emailTo, "Receiver");
                var password = _authenticatePaswd;
                var sub = emailSubject;
                var body = emailMessage;

                var smtp = new SmtpClient
                {
                    Host = "smtp-relay.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(authenticateSenderEmail.Address, password)
                };
                var htmlBody = AlternateView.CreateAlternateViewFromString(emailMessage, Encoding.UTF8, "text/html");
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub
                })
                {
                    mess.AlternateViews.Add(htmlBody);
                    smtp.Send(mess);
                }
                _return = "Success send eEmail to " + emailTo;
            }
            catch (Exception ex)
            {
                _return = "Error OutlookSendEmail TryCatch : " + ex;
            }
            return _return;
        }

        public static string GmailSendEmailFromLocal(string emailTo, string emailSubject, string emailMessage, string gmailAuthenticateEmail, string gmailAuthenticatePassword)
        {
            string _authenticateEmail = EncryptHr.DecryptString4url(gmailAuthenticateEmail, "admSmis");
            string _authenticatePaswd = EncryptHr.DecryptString4url(gmailAuthenticatePassword, "admSmis");

            string _return = "";
            try
            {
                var authenticateSenderEmail = new MailAddress(_authenticateEmail, "Sender");
                var senderEmail = new MailAddress(_authenticateEmail, "UPNM-Visa Admin");
                var receiverEmail = new MailAddress(emailTo, "Receiver");
                var password = _authenticatePaswd;
                var sub = emailSubject;
                var body = emailMessage;

                var smtp = new SmtpClient
                {
                    Host = "smtp.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(authenticateSenderEmail.Address, password)
                };
                var htmlBody = AlternateView.CreateAlternateViewFromString(emailMessage, Encoding.UTF8, "text/html");
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub
                })
                {
                    mess.AlternateViews.Add(htmlBody);
                    smtp.Send(mess);
                }
                _return = "Success send eEmail to " + emailTo;
            }
            catch (Exception ex)
            {
                _return = "Error OutlookSendEmail TryCatch : " + ex;
            }
            return _return;
        }

        public static string GmailSendEmailWithTitle(string emailFrom, string emailTo, string emailSubject, string emailMessage, string gmailAuthenticateEmail, string gmailAuthenticatePassword, string emailFromTitle)
        {
            string _authenticateEmail = EncryptHr.DecryptString4url(gmailAuthenticateEmail, "admSmis");
            string _authenticatePaswd = EncryptHr.DecryptString4url(gmailAuthenticatePassword, "admSmis");

            //log.Info("OutlookSendEmail emailTo ~ " + emailTo);
            //log.Info("OutlookSendEmail _authenticateEmail ~ " + _authenticateEmail);
            //log.Info("OutlookSendEmail _authenticatePaswd ~ " + _authenticatePaswd);

            string _return = "";
            try
            {
                var authenticateSenderEmail = new MailAddress(_authenticateEmail, "Sender");
                var senderEmail = new MailAddress(_authenticateEmail, (emailFromTitle != null ? emailFromTitle : "UPNM-HR Admin"));
                var receiverEmail = new MailAddress(emailTo, "Receiver");
                var password = _authenticatePaswd;
                var sub = emailSubject;
                var body = emailMessage;

                var smtp = new SmtpClient
                {
                    //Host = "smtp.outlook.com",
                    Host = "smtp-relay.outlook.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(authenticateSenderEmail.Address, password)
                };
                var htmlBody = AlternateView.CreateAlternateViewFromString(emailMessage, Encoding.UTF8, "text/html");
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub
                })
                {
                    mess.AlternateViews.Add(htmlBody);
                    smtp.Send(mess);
                }
                _return = "Success send eEmail to " + emailTo;
            }
            catch (Exception ex)
            {
                _return = "Error OutlookSendEmail TryCatch : " + ex;
            }
            return _return;
        }

        public static string GmailSendEmailByodWithTitle(string emailFrom, string emailTo, string emailSubject, string emailMessage, string gmailAuthenticateEmail, string gmailAuthenticatePassword, string emailFromTitle)
        {
            string _authenticateEmail = EncryptHr.DecryptString4url(gmailAuthenticateEmail, "admSmis");
            string _authenticatePaswd = EncryptHr.DecryptString4url(gmailAuthenticatePassword, "admSmis");

            string _return = "";
            try
            {
                var authenticateSenderEmail = new MailAddress(_authenticateEmail, "Sender");
                var senderEmail = new MailAddress(_authenticateEmail, (emailFromTitle != null ? emailFromTitle : "BYOD Admin"));
                var receiverEmail = new MailAddress(emailTo, "Receiver");
                var password = _authenticatePaswd;
                var sub = emailSubject;
                var body = emailMessage;

                SmtpClient smtp = (SmtpClient)MtdGeSmtpRelayGmailCom(authenticateSenderEmail, password);

                var htmlBody = AlternateView.CreateAlternateViewFromString(emailMessage, Encoding.UTF8, "text/html");
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub
                })
                {
                    mess.AlternateViews.Add(htmlBody);
                    smtp.Send(mess);
                }
                _return = "Success send eEmail to " + emailTo;
            }
            catch (Exception ex)
            {
                _return = "Error OutlookSendEmail TryCatch : " + ex;
            }
            return _return;
        }

        private static object MtdGeSmtpRelayGmailCom(MailAddress authenticateSenderEmail, string password)
        {
            return new SmtpClient
            {
                //Host = "smtp.outlook.com",
                Host = "smtp-relay.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(authenticateSenderEmail.Address, password)
            };
        }

        public static bool IsValidEmail(string _textNya)
        {
            // [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
            try
            {
                var addr = new System.Net.Mail.MailAddress(_textNya);
                return addr.Address == _textNya;
            }
            catch
            {
                return false;
            }
        }
    }
}
