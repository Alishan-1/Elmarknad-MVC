using Elmarknad.Models;
using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ClientModel GetSingleClient(int id)
        {
            return db.ClientModels.Find(id);
        }

        public void UpdateClientDeal(AddDealViewModel model)
        {
            var _db = new DbEl();
            var deal = _db.ClientModels.Find(model.ClientId);
            var HasChange = EqualsClient(model, deal);
            if (HasChange)
                return;

            if (_db.Customers.Any(i => i.ClientId == deal.ClientId))
                throw new Exception();

            _db.ClientModels.Remove(deal);
            SaveDeal(model);

            _db.SaveChanges();
        }

        public bool EqualsClient(AddDealViewModel model, ClientModel client)
        {
            return model.Appartment != client.Appartment ? false :
                   model.Autogiro != client.Autogiro ? false :
                   model.Automatiskförlängning != client.Automatiskförlängning ? false :
                   model.Bio != client.Bio ? false :
                   model.Contract != client.Contract ? false :
                   model.EFaktura != client.EFaktura ? false :
                   model.ElBolagId != client.ElBolagId ? false :
                   model.ElområdeId != client.ElområdeId ? false :
                   model.Engångsavgift != client.Engångsavgift ? false :
                   model.ExtraInfo != client.ExtraInfo ? false :
                   model.Fastpris != client.Fastpris ? false :
                   model.House != client.House ? false :
                   model.MaxFörbrukning != client.Förbrukning ? false :
                   model.Miljömärkt != client.Miljömärkt ? false :
                   model.Miljöpåslag != client.Miljöpåslag ? false :
                   model.MinFörbrukning != client.MinFörbrukning ? false :
                   model.Moms != client.Moms ? false :
                   model.Omteckningsrätt != client.Omteckningsrätt ? false :
                   model.Pappersfaktura != client.Pappersfaktura ? false :
                   model.Price != client.Price ? false :
                   model.Rabatt != client.Rabatt ? false :
                   model.Rating != client.Rating ? false :
                   model.RörligtInköpsPris != client.RörligtInköpsPris ? false :
                   model.RörligtMiljöpåslag != client.RörligtMiljöpåslag ? false :
                   model.RörligtPåslag != client.RörligtPåslag ? false :
                   model.Sol != client.Sol ? false :
                   model.Typ != client.Typ ? false :
                   model.Uppsägningstid != client.Uppsägningstid ? false :
                   model.Vatten != client.Vatten ? false :
                   model.Vind != client.Vind ? false :
                   model.ÅrsAvgift != client.ÅrsAvgift ? false : true;
            
        }

        public AddDealViewModel FillDealModel() {
            var model = new AddDealViewModel
            {
                ElBolag = GetElbolag(),
                Elområde = GetElområde()
            };
            return model;
        }
        public void SaveDealAllAreas(AddDealViewModel deal)
        {
            var elområden = db.Elområden.ToList();
            foreach(var item in elområden)
            {
                deal.ElområdeId = item.ElområdeId;
                SaveDeal(deal);
            }
        }
        public void SaveDeal(AddDealViewModel deal) {
            
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
                MinFörbrukning = deal.MinFörbrukning,
                Appartment = deal.Appartment,
                Autogiro = deal.Autogiro,
                Bio = deal.Bio,
                EFaktura = deal.EFaktura,
                House = deal.House,
                Miljömärkt = deal.Miljömärkt,
                Pappersfaktura = deal.Pappersfaktura,
                Vind = deal.Vind,
                Sol = deal.Sol,
                Vatten = deal.Vatten,
                Förbrukning = deal.MaxFörbrukning,
                Rating = deal.Rating,
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