using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elmarknad.Models.ViewModels
{
    public class ListSearchResultViewModel
    {
        public List<SearchResultViewModel> Clients { get; set; }
        public List<SearchResultViewModel> Scraped { get; set; }
        public string Typ { get; set; }
        private Dictionary<string, string> _Typ = new Dictionary<string, string>
        {
            {"Rörligt", "Rörligt"},
            {"Fast", "Fast"},
            {"Mix", "Mix"},
        };

        public IEnumerable<SelectListItem> TypList
        {
            get { return new SelectList(_Typ, "Key", "Value"); }
        }
        public string Förbrukning { get; set; }
        public string Postnummer { get; set; }
        public int ElId { get; set; }
    }
}