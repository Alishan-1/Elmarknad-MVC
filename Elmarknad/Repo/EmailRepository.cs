using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using Elmarknad.Models.ViewModels;
using System.IO;

namespace Elmarknad.Repo
{
    public class EmailRepository
    {
        public void SendEmailAsync(SignDealViewModel model) {

            var body = GetEmailTemplate();
            var message = new MailMessage();
            message.To.Add(new MailAddress(model.CustomerInfo.Email));  // replace with valid value 
            message.From = new MailAddress("billybolero1@gmail.com");  // replace with valid value
            message.Subject = "Tack för att du valt oss";
            message.Body = body;
            message.IsBodyHtml = true;

                var smtp = new SmtpClient();
            
                var credential = new NetworkCredential
                {
                    UserName = "billybolero1@gmail.com",  // replace with valid value
                    Password = "Samuel22."  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(message);
                
            
        }

        private string GetEmailTemplate() {
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Repo/"), "EmailTemplate.html");
            string html = File.ReadAllText(path);
            return html;
        }
    }
}


