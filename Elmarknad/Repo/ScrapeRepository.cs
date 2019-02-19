using Elmarknad.Models.Webscrape;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace Elmarknad.Repo
{
    public class ScrapeRepository
    {
        private bool IsExisting(string typ, int förbrukning, int ElområdeId)
        {
            DbEl db = new DbEl();
            return db.ScrapeModels.Any(i => i.Typ == typ && i.Förbrukning == förbrukning && i.ElområdeId == ElområdeId);
        }
        private void RemoveContent(string typ, int förbrukning, int ElområdeId)
        {
            DbEl db = new DbEl();
            var list = db.ScrapeModels.Where(i => i.Typ == typ && i.Förbrukning == förbrukning && i.ElområdeId == ElområdeId).ToList();
            db.ScrapeModels.RemoveRange(list);
            db.SaveChanges();
        }

        public async Task<bool> GetHtmlAsync(string typ, int förbrukning, string url, int ElområdeId)
        {
            DbEl db = new DbEl();
            var r = new Random();
            if (IsExisting(typ, förbrukning, ElområdeId)) {
                RemoveContent(typ, förbrukning, ElområdeId);
            }

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var AllListElements = htmlDoc.DocumentNode.Descendants("li")
                 .Where(node => node.GetAttributeValue("class", "")
                 .StartsWith("panel epk-list-item")).ToList();

            var Links = htmlDoc.DocumentNode.Descendants("a")
                        .Where(node => node.GetAttributeValue("href", "")
                        .StartsWith("/sv/Elpriskollen/Avtalssida/?ellevid="))
                        .Select(i => i.GetAttributeValue("href", "").Replace("amp;", "")).ToList();

            var headers = AllListElements.Select(i => i.Descendants("h3").Select(x => x.InnerText).ToList()).ToList();

            var Price = htmlDoc.DocumentNode.Descendants("div")
                 .Where(node => node.GetAttributeValue("class", "")
                 .Equals("epk-list-price col-md-2 col-sm-3 ")).Select(i => i.InnerText).ToList();

            var Company = htmlDoc.DocumentNode.Descendants("dd")
                         .Where(node => node.GetAttributeValue("class", "")
                         .Equals("epk-list-contract-company")).Select(i => i.InnerText).ToList();

            var Contract = htmlDoc.DocumentNode.Descendants("dd")
                          .Where(node => node.GetAttributeValue("class", "")
                          .Equals("epk-list-contract-type")).Select(i => i.InnerText).ToList();



            var list = new List<ScrapeModel>();
            for (int i = 0; i < Links.Count; i++)
            {
                var model = new ScrapeModel();
                model.Company = Company[i].Trim();
                model.Contract = Contract[i].Trim();
                model.Price = Price[i].Trim();
                model.ExtraInfo = headers[i][0].Trim();
                model.Typ = typ;
                model.Förbrukning = förbrukning;
                model.ElområdeId = ElområdeId;
                model.Rating = 0;
                var extraUrl = "https://www.ei.se" + Links[i];
                var extraClient = new HttpClient();
                var extraHtml = await httpClient.GetStringAsync(extraUrl);

                var extraHtmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(extraHtml);

                var ExtraAttributes = htmlDoc.DocumentNode.Descendants("td")
                                     .Where(node => node.GetAttributeValue("class", "")
                                     .StartsWith("value")).Select(node => node.InnerText.Trim()).ToList();

                model.ÅrsAvgift = ExtraAttributes[0];
                model.Engångsavgift = ExtraAttributes[1];
                model.Fastpris = ExtraAttributes[2];
                model.RörligtInköpsPris = ExtraAttributes[3];
                model.RörligtPåslag = ExtraAttributes[4];
                model.Miljöpåslag = ExtraAttributes[5];
                model.RörligtMiljöpåslag = ExtraAttributes[6];
                model.Rabatt = ExtraAttributes[7];
                model.Moms = ExtraAttributes[10];
                model.Uppsägningstid = ExtraAttributes[15];
                model.Automatiskförlängning = ExtraAttributes[16];
                model.Omteckningsrätt = ExtraAttributes[17];
                list.Add(model);
            }
            db.ScrapeModels.AddRange(list);
            db.SaveChanges();
            return true;
           
        }



    }

    
}