using Elmarknad.Models.ViewModels;
using Elmarknad.Models.Webscrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elmarknad.Repo
{
    public class SearchResultRepository
    {
        private DbEl db = new DbEl();

        public ListSearchResultViewModel FillSearchResultModel(SearchViewModel m) {
            var elId = GetElområdeId(m.Postnummer);
            var model = new ListSearchResultViewModel();

            model.Agreements = GetClients(m.Typ, m.Förbrukning, elId);
            model.Agreements.AddRange(GetScraped(m.Typ, m.Förbrukning, elId));
            model.Förbrukning = m.Förbrukning;
            model.Typ = m.Typ;
            model.ElId = elId;
            model.Postnummer = m.Postnummer.ToString();
            return model;
        }

        public ListSearchResultViewModel FilterByRating(int förbrukning, string typ, int elId)
        {

            var model = new ListSearchResultViewModel();

            model.Agreements = GetClients(typ, förbrukning, elId);
            model.Agreements.AddRange(GetScraped(typ, förbrukning, elId));

            model.Agreements = model.Agreements.OrderByDescending(i => i.Rating).ToList();
            model.Typ = typ;
            return model;
        }

        public ListSearchResultViewModel FilterByPrice(int förbrukning, string typ, int elId)
        {

            var model = new ListSearchResultViewModel();
            
            model.Agreements = GetClients(typ, förbrukning, elId);
            model.Agreements.AddRange(GetScraped(typ,förbrukning, elId));

            model.Agreements = model.Agreements.OrderBy(i => i.Price).ToList();

            model.Typ = typ;
            return model;
        }

        private List<SearchResultViewModel> GetClients(string typ, int förbrukning, int elId) {
            
            var clients = db.ClientModels.Where(i => i.ElområdeId == elId && i.Typ == typ && i.Förbrukning == förbrukning).ToList();
            var list = new List<SearchResultViewModel>();
            foreach (var item in clients) {
                var model = new SearchResultViewModel
                {
                    Id = item.ClientId,
                    Company = item.ElBolag.Name,
                    Rating = (decimal)item.Rating,
                    Avtalstid = 12,
                    Contract = item.Contract,
                    ExtraInfo = item.ExtraInfo,
                    Image = item.ElBolag.Image,
                    Price = item.Price,
                    Uppsägningstid = item.Uppsägningstid,
                    IsClient = true,
                    AutomatiskFörlängning = item.Automatiskförlängning,
                    Omteckningsrätt = item.Omteckningsrätt,
                    Bio = item.Bio,
                    Miljömärkt = item.Miljömärkt,
                    Sol = item.Sol,
                    Vatten = item.Vatten,
                    Vind = item.Vind
                };
                list.Add(model);
            }
            return list;
        }



        private List<SearchResultViewModel> GetScraped(string typ, int förbrukning, int elId)
        {

            var scraped = db.ScrapeModels.Where(i => i.ElområdeId == elId && i.Typ == typ && i.Förbrukning == förbrukning).ToList();

            var list = new List<SearchResultViewModel>();
            foreach (var item in scraped)
            {
                var model = new SearchResultViewModel
                {
                    Id = item.ScrapeId,
                    Company = item.Company,
                    Rating = (decimal)item.Rating,
                    Avtalstid = 12,
                    Contract = item.Contract,
                    ExtraInfo = item.ExtraInfo,
                    Price = ConvertPrice(item.Price),
                    IsClient = false,
                    Image = null,
                    Uppsägningstid = item.Uppsägningstid,
                    AutomatiskFörlängning = item.Omteckningsrätt,
                    Omteckningsrätt = item.Omteckningsrätt,
                    Bio = item.Bio,
                    Miljömärkt = item.Miljömärkt,
                    Sol = item.Sol,
                    Vatten = item.Vatten,
                    Vind = item.Vind
                };
                list.Add(model);
            }
            return list;
        }

        private decimal ConvertPrice(string price)
        {
            return decimal.Parse(price.Split(' ')[0]);
        }

        private int GetElområdeId(int postnummer) {
            var id = db.Postnummers.Where(i => i.Number == postnummer).Select(i => i.ElområdeId).First();
            return id;
        }
    }
}