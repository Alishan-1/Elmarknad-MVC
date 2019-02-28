using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Repo
{
    public class CustomerDealRepository
    {
        private DbEl db = new DbEl();

        public SignDealViewModel GetScrapedModel(int id) {
            try
            {
                var deal = db.ScrapeModels.Find(id);
                var model = new SignDealViewModel
                {
                    Automatiskförlängning = deal.Automatiskförlängning,
                    Company = deal.Company,
                    Contract = deal.Contract,
                    Engångsavgift = deal.Engångsavgift,
                    ExtraInfo = deal.ExtraInfo,
                    Fastpris = deal.Fastpris,
                    Förbrukning = deal.Förbrukning,
                    Miljöpåslag = deal.Miljöpåslag,
                    Moms = deal.Moms,
                    Omteckningsrätt = deal.Omteckningsrätt,
                    Price = deal.Price,
                    Rabatt = deal.Rabatt,
                    Rating = deal.Rating,
                    RörligtInköpsPris = deal.RörligtInköpsPris,
                    RörligtMiljöpåslag = deal.RörligtMiljöpåslag,
                    RörligtPåslag = deal.RörligtPåslag,
                    ScrapeId = deal.ScrapeId,
                    Typ = deal.Typ,
                    Uppsägningstid = deal.Uppsägningstid,
                    ÅrsAvgift = deal.ÅrsAvgift,
                    Bio = deal.Bio,
                    Miljömärkt = deal.Miljömärkt,
                    Sol = deal.Sol,
                    Vatten = deal.Vatten,
                    Vind = deal.Vind,
                    CustomerInfo = new AddCustomerAdminViewModel()
                };
                if (deal.Pappersfaktura)
                {
                    model.CustomerInfo._Payment.Add("Pappersfaktura", "Pappersfaktura");
                }
                if (deal.EFaktura)
                {
                    model.CustomerInfo._Payment.Add("E-Faktura", "E-Faktura");
                }
                if (deal.Autogiro)
                {
                    model.CustomerInfo._Payment.Add("Autogiro", "Autogiro");
                }
                
                return model;
            }
            catch {
                throw new Exception();
            }
            
        }

        public SignDealViewModel GetClientModel(int id)
        {
            try
            {
                var deal = db.ClientModels.Find(id);
                var model = new SignDealViewModel
                {
                    Automatiskförlängning = deal.Automatiskförlängning,
                    Company = deal.ElBolag.Name,
                    Contract = deal.Contract,
                    Engångsavgift = deal.Engångsavgift.ToString(),
                    ExtraInfo = deal.ExtraInfo,
                    Fastpris = deal.Fastpris.ToString(),
                    Förbrukning = deal.Förbrukning,
                    Miljöpåslag = deal.Miljöpåslag.ToString(),
                    Moms = deal.Moms.ToString(),
                    Omteckningsrätt = deal.Omteckningsrätt,
                    Price = deal.Price.ToString(),
                    Rabatt = deal.Rabatt.ToString(),
                    Rating = deal.Rating,
                    RörligtInköpsPris = deal.RörligtInköpsPris.ToString(),
                    RörligtMiljöpåslag = deal.RörligtMiljöpåslag.ToString(),
                    RörligtPåslag = deal.RörligtPåslag.ToString(),
                    ScrapeId = deal.ClientId,
                    Typ = deal.Typ,
                    Uppsägningstid = deal.Uppsägningstid,
                    ÅrsAvgift = deal.ÅrsAvgift.ToString(),
                    CustomerInfo = new AddCustomerAdminViewModel(),
                    Image = deal.ElBolag.Image,
                    Bio = deal.Bio,
                    Miljömärkt = deal.Miljömärkt,
                    Sol = deal.Sol,
                    Vatten = deal.Vatten,
                    Vind = deal.Vind
                };
                if (deal.Pappersfaktura)
                {
                    model.CustomerInfo._Payment.Add("Pappersfaktura", "Pappersfaktura");
                }
                if (deal.EFaktura)
                {
                    model.CustomerInfo._Payment.Add("E-Faktura", "E-Faktura");
                }
                if (deal.Autogiro)
                {
                    model.CustomerInfo._Payment.Add("Autogiro", "Autogiro");
                }
                return model;

            }
            catch {
                throw new Exception();
            }
            
        }

    }
}