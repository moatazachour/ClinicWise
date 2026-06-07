using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClinicWise.Business.Services
{
    public class EmailService
    {
        private static readonly string _smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        private static readonly int _smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        private static readonly string _smtpUser = ConfigurationManager.AppSettings["SmtpUser"];
        private static readonly string _smtpPass = ConfigurationManager.AppSettings["SmtpPass"];



        public static void SendEmail(string to, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient(_smtpHost, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                    smtpClient.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpUser),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = false
                    };

                    mailMessage.To.Add(to);

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw;
            }
        }
    }
}
