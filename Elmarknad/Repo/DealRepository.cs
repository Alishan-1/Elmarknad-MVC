using Elmarknad.Models;
using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Repo
{
    public class DealRepository
    {
        private DbEl db = new DbEl();

        private List<Elområde> GetElområde() {
            return db.Elområden.ToList();
        }
        private List<ElBolag> GetElbolag()
        {
            return db.Companies.ToList();
        }
        public AddDealViewModel FillDealModel() {
            var model = new AddDealViewModel
            {
                ElBolag = GetElbolag(),
                Elområde = GetElområde()
            };
            return model;
        }

        public void SaveDeal(AddDealViewModel deal) {
            var r = new Random();
            var client = new ClientModel
            {
                Price = deal.Price,
                Automatiskförlängning = deal.Automatiskförlängning,
                Contract = deal.Contract,
                ElBolagId = deal.ElBolagId,
                ElområdeId = deal.ElområdeId,
                Engångsavgift = deal.Engångsavgift,
                ExtraInfo = deal.ExtraInfo,
                Fastpris = deal.Fastpris,
                Förbrukning = deal.Förbrukning,
                Rating = r.Next(75, 99),
                Miljöpåslag = deal.Miljöpåslag,
                ÅrsAvgift = deal.ÅrsAvgift,
                Uppsägningstid = deal.Uppsägningstid,
                Typ = deal.Typ,
                Moms = deal.Moms,
                Omteckningsrätt = deal.Omteckningsrätt,
                RörligtPåslag = deal.RörligtPåslag,
                RörligtMiljöpåslag = deal.RörligtMiljöpåslag,
                RörligtInköpsPris = deal.RörligtInköpsPris,
                Rabatt = deal.Rabatt
            };
            db.ClientModels.Add(client);
            db.SaveChanges();
        }

        public DisplayDealsViewModel FillAllDealsModel() {
            var model = new DisplayDealsViewModel
            {
                Deals = db.ClientModels.ToList()
            };
            return model;
        }
        public void DeleteDeal(int id)
        {
            var agreement = db.ClientModels.Single(i => i.ClientId == id);
            if (agreement != null)
            {
                db.ClientModels.Remove(agreement);
                db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

    }
}