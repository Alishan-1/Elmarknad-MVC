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

            model.Clients = GetClients(m.Typ, m.Förbrukning, elId);
            model.Scraped = GetScraped(m.Typ, m.Förbrukning, elId);
            model.Förbrukning = m.Förbrukning.ToString();
            model.Typ = m.Typ;
            model.ElId = elId;
            model.Postnummer = m.Postnummer.ToString();
            return model;
        }

        public ListSearchResultViewModel FilterByRating(int förbrukning, string typ, int elId)
        {
           
            var model = new ListSearchResultViewModel();

            model.Clients = GetClients(typ, förbrukning, elId).OrderBy(i => i.Rating).ToList();
            model.Scraped = GetScraped(typ, förbrukning, elId).OrderBy(i => i.Rating).ToList();
            return model;
        }

        private List<SearchResultViewModel> GetClients(string typ, int förbrukning, int elId) {
            
            var clients = db.ClientModels.Where(i => i.ElområdeId == elId && i.Typ == typ && i.Förbrukning == förbrukning).ToList();
            var list = new List<SearchResultViewModel>();
            foreach (var item in clients) {
                var model = new SearchResultViewModel
                {
                    SearchId = item.ClientId,
                    Company = item.ElBolag.Name,
                    Rating = (decimal)item.Rating,
                    Avtalstid = 12,
                    Contract = item.Contract,
                    ExtraInfo = item.ExtraInfo,
                    Image = item.ElBolag.Image,
                    Price = item.Price.ToString(),
                    Uppsägningstid = item.Uppsägningstid
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
                    SearchId = item.ScrapeId,
                    Company = item.Company,
                    Rating = (decimal)item.Rating,
                    Avtalstid = 12,
                    Contract = item.Contract,
                    ExtraInfo = item.ExtraInfo,
                    Price = item.Price,
                    Uppsägningstid = item.Uppsägningstid
                };
                list.Add(model);
            }
            return list;
        }

        private int GetElområdeId(int postnummer) {
            var id = db.Postnummers.Where(i => i.Number == postnummer).Select(i => i.ElområdeId).First();
            return id;
        }
    }
}