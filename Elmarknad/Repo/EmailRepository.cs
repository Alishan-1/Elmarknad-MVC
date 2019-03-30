using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using Elmarknad.Models.ViewModels;
using System.IO;
using Elmarknad.Models.Webscrape;

namespace Elmarknad.Repo
{
    public class EmailRepository
    {
        public void SendEmailAsync(SignDealViewModel model) {

            var body = GetEmailTemplate(model);
            var message = new MailMessage();
            message.To.Add(new MailAddress(model.CustomerInfo.Email));  // replace with valid value 
            message.From = new MailAddress("billybolero1@gmail.com", "Elmarknad");  // replace with valid value
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
        private SignDealViewModel GetCompany(SignDealViewModel model)
        {
            SignDealViewModel sign;

            var helper = new CustomerDealRepository();
            if (model.IsClient)
            {

                sign = helper.GetClientModel(model.ScrapeId);

            }
            else
            {
                sign = helper.GetScrapedModel(model.ScrapeId);
            }
            return sign;
        }
        
        private string GetEmailTemplate(SignDealViewModel model)  {


            var company = GetCompany(model);

            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Repo/"), "EmailTemplate.html");
            string html = File.ReadAllText(path);
            string pathFooter = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Repo/"), "EmailTemplateFooter.html");
            string htmlFooter = File.ReadAllText(pathFooter);
            var email = html + "<tr>" +
                        "<td align='center' valign='top' style='border-collapse: collapse; border-spacing: 0; margin: 0; padding: 0; padding-left: 10px; padding-right: 10px;' class='floaters'>" +
                            "<table width='400' border='0' cellpadding='0' cellspacing='0' align='right' valign='top' style=' mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-spacing: 0; margin: 0; padding: 0; display: inline-table; float: none;' class='floater'>" +
                                "<tr>" +
                                    "<td align='center' valign='top' style='border:1px solid #808080 !important; border-spacing: 0; margin: 0; padding: 0; padding-left: 15px; padding-right: 15px; font-size: 17px; font-weight: 400; line-height: 160%;" +
                                    "padding-top: 30px;padding-bottom: 30px;" +
                                    "font-family: sans-serif;" +
                                    "color: #000000;'>" +
                                    "<h3 style='color:#0B5073; text-decoration: underline;'>Uppgifter från dig</h3>" +
                                        "<br />" +
                                        "<table class='custom-table' style='border-collapse: separate !important; border: 1px solid #1b5b82; list-style:none;'>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Namn: </th>" +
                                                "<td>" + model.CustomerInfo.Firstname + " " + model.CustomerInfo.Lastname + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Personummer: </th>" +
                                                "<td>" + model.CustomerInfo.SocialSecurity + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Epost: </th>" +
                                                "<td>" + model.CustomerInfo.Email +  "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Adress: </th>" +
                                                "<td>" + model.CustomerInfo.Address  + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Postnummer: </th>" +
                                                "<td>" + model.CustomerInfo.Postnumber +  "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Ort: </th>" +
                                                "<td>" + model.CustomerInfo.City + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Betalmetod: </th>" +
                                                "<td>" + model.CustomerInfo.Paymentmethod +  "</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                             "<table width='400' border='0' cellpadding='0' cellspacing='0' align='right' valign='top' style='mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-spacing: 0; margin: 0; padding: 0; margin-top: 50px !important; display: inline-table; float: none;' class='floater'>" +
                                "<tr>" +
                                    "<td align='center' valign='top' style='border:1px solid #808080; border-spacing: 0; margin: 0; padding: 0; padding-left: 15px; padding-right: 15px; font-size: 17px; font-weight: 400; line-height: 160%;" +
                                    "padding-top: 30px;padding-bottom: 30px;" +
                                    "font-family: sans-serif;" +
                                    "color: #000000;'>" +
                                    "<h3 style='color:#0B5073; text-decoration: underline;'>Uppgifter om ditt elavtal</h3>" +
                                        "<br />" +
                                        "<table  class='custom-table' style='border-collapse: separate !important; border: 1px solid #1b5b82; list-style:none;'>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Elbolag: </th>" +
                                                "<td>" + company.Company +  "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Avtal: </th>" +
                                                "<td>" + company.Contract + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Totalt Pris: </th>" +
                                                "<td>" + company.Price + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Automatiskförlängning: </th>" +
                                                "<td>" + company.Automatiskförlängning + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Omteckningsrätt: </th>" +
                                                "<td>" + company.Omteckningsrätt + " </td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Uppsägningstid: </th>" +
                                                "<td>" + company.Uppsägningstid + "</td>" +
                                            "</tr>" +
                                            "<tr align='left'>" +
                                                "<th style='font-weight: 600'>Övrig info: </th>" +
                                                "<td>" + company.ExtraInfo + "</td>" +
                                            "</tr>" +
                                        "</table>" +
                                    "</td>" +
                                "</tr>" +
                            "</table></td></tr>" + htmlFooter;

            
            
            return email;
        }

        private string SerializeToPdf(SignDealViewModel m) {
            return null;
        }

        

        public void CustomerSupportEmail(CustomerEmailViewModel model) {

            var body = "<html>" +
                        "<body><table>" +
                        "<tr>" +
                        "<th>" + "Avsändare" +
                            "</th>" +
                            "<th>" + "Avsändarens epost" +
                            "</th>" +
                            "<th>" + "Ämne" +
                            "</th>" +
                        "</tr>" +
                        "<tr>" +
                        "<td>" + model.Sender + "</td>" +
                        "<td>" + model.Email + "</td>" +
                        "<td>" + model.Subject + "</td>" +
                        "</tr>" +
                        "</table>" + "<p><b>Meddelande: </b>" + model.Message +
                        "</body></html>";

            var message = new MailMessage();
            message.To.Add(new MailAddress("samuel@elmarknad.se"));
            message.To.Add(new MailAddress("oliwer@elmarknad.se"));
            message.To.Add(new MailAddress("andreas@elmarknad.se")); 
            message.From = new MailAddress("billybolero1@gmail.com", "Elmarknad");
            message.Subject = "Nytt meddelande till kundtjänst";
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
    }
}


